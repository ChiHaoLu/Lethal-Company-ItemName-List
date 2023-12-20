using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string projectPath = @"C:\Users\qazws\Desktop\工作\接案\LCDecompile";
        FindGrabbableObjects(projectPath);
    }

    static void FindGrabbableObjects(string projectPath)
    {
        var syntaxTrees = Directory.GetFiles(projectPath, "*.cs", SearchOption.AllDirectories)
            .Select(path => CSharpSyntaxTree.ParseText(File.ReadAllText(path), new CSharpParseOptions(LanguageVersion.Latest), path));

        Console.WriteLine("Grabbable Objects found:");
        foreach (var syntaxTree in syntaxTrees)
        {
            var root = syntaxTree.GetRoot();
            var grabbableDeclarationsClass = root.DescendantNodes()
                .Where(node => node.IsKind(SyntaxKind.ClassDeclaration))
                .OfType<ClassDeclarationSyntax>()
                .Where(declaration =>
                {
                    if (declaration is ClassDeclarationSyntax classDeclaration)
                        return classDeclaration.BaseList?.Types.Any(type => type.ToString() == "GrabbableObject") ?? false;
                    return false;
                });
            var grabbableDeclarationsVar = root.DescendantNodes()
                .Where(node => node.IsKind(SyntaxKind.VariableDeclaration))
                .OfType<VariableDeclarationSyntax>()
                .Where(declaration =>
                {
                    if (declaration is VariableDeclarationSyntax variableDeclaration)
                        return variableDeclaration.Type.ToString() == "GrabbableObject";
                    return false;
                });
            foreach (var grabbableObject in grabbableDeclarationsClass)
            {
                Console.WriteLine(grabbableObject.Identifier.ValueText);
            }

            foreach (var variableDeclaration in grabbableDeclarationsVar)
            {
                foreach (var variable in variableDeclaration.Variables)
                {
                    Console.WriteLine(variable.Identifier.ValueText);
                }
            }

        }

    }
}
