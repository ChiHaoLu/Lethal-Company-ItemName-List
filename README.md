# Lethal Company ItemName List

If you interest in how to get the Item list, please refer [How to get Item List](#How-to-get-Item-List). If not, checking the [Item List](#Item-List) directly.

### Motivation

When people who don't know programming want to add/delete item in the mod's config, they are confused what item name should input.

For example, user doesn't know how to add a new item [here](https://github.com/SirTyler/BetterTeleporter/blob/main/Plugin.cs#L256).


### Item List

**In my speculation**, there may be several items classified under the same category. For example, both a Regular Flashlight and a Pro Flashlight are defined within the `FlashlightItem` category. This is why some items have the suffix `Item` while others do not.

#### Sure Item
| Item Name | Trad.CH |
|---|---|
|RagdollGrabbableObject|布娃娃可抓取物體|
|KeyItem|鑰匙物品|
|GunAmmo|槍彈藥|
|GiftBoxItem|禮盒物品|
|LungProp|肺部道具|
|ClipboardItem|剪貼板物品|
|ExtensionLadderItem|伸縮梯物品|
|BoomboxItem|音樂盒物品|
|FlashlightItem|手電筒物品|
|WhoopieCushionItem|放屁墊物品|
|BinocularsItem|雙筒望遠鏡物品|
|SprayPaintItem|噴漆物品|
|HauntedMaskItem|鬼面具物品|
|RadarBoosterItem|雷達增強器物品|
|Hive|蜂巢|
|MapDevice|地圖裝置|
|AnimatedItem|動畫物品|
|StunGrenadeItem|閃光手榴彈物品|
|Shovel|鏟子|
|RemoteProp|遙控道具|
|ShotgunItem|獵槍物品|
|TetraChemicalItem|四元化學物品|
|PhysicsProp|物理道具|
|WalkieTalkie|對講機|
|LockPicker|開鎖器|
|NoisemakerProp|噪音製造道具|
|JetpackItem|噴射背包物品|
|PatcherTool|修補工具|
|ClipboardItem|剪貼板物品|

#### Not Sure Item

This list is internal variable in some object, but they are also `GrabbableObject`. For example, the [hive](https://github.com/ChiHaoLu/Lethal-Company-ItemName-List/blob/main/RedLocustBees.cs#L16) in the `RedLocustBees.cs`.

If anyone has tried below item name and know it is useful or not, pls tell me.

| Item Name | Trad.CH |
|---|---|
|focusedScrap|集中的廢棄物|
|heldScrap|持有的廢棄物|
|grabBodyObject|抓取大體|
|pocketedFlashlight|放入口袋的手電筒|
|attachedGrabbableObject|附著的可抓取物體|
|hive|蜂巢|



### How to get Item List

#### Method1
The purpose of this code is to traverse all `.cs` files within a specified C# project path, searching for and printing two types of "GrabbableObject":

1. **GrabbableObject Classes:**
   - Utilizes the Roslyn C# syntax tree analysis tool.
   - Iterates through each syntax tree, identifying all `ClassDeclarationSyntax`, i.e., class declarations.
   - Filters out classes that inherit from "GrabbableObject" from these declarations.
   - Prints the names of these classes.

2. **GrabbableObject Variables:**
   - Similarly uses the Roslyn C# syntax tree analysis tool.
   - Iterates through each syntax tree, identifying all `VariableDeclarationSyntax`, i.e., variable declarations.
   - Filters out variables of type "GrabbableObject" from these declarations.
   - Prints the names of these variables.

The execution steps of this code are as follows:

1. Set the project path.
2. Use `Directory.GetFiles` to obtain paths for all `.cs` files.
3. Use `CSharpSyntaxTree.ParseText` to convert the code of each file into a Roslyn syntax tree.
4. Traverse each syntax tree, searching for class and variable declarations that meet the specified conditions.
5. Print the names of classes and variables that meet the conditions.

In summary, this code is designed to find and print the names of classes and variables related to "GrabbableObject" within a project.

You can see there are some `var`/`class` name weird, I will try to solve it in the future in leisure time.

```
Grabbable Objects found:
AnimatedItem
focusedScrap
heldScrap
grabbableObject
grabbableObject
component3
BinocularsItem
BoomboxItem
ClipboardItem
grabBodyObject
ExtensionLadderItem
FlashlightItem
GiftBoxItem
component
component
GunAmmo
HauntedMaskItem
targetItem
component
itemGrabbableObject
component
itemGrabbableObject
currentlyHeldObjectServer
JetpackItem
KeyItem
LockPicker
LungProp
MapDevice
NoisemakerProp
PatcherTool
PhysicsProp
RadarBoosterItem
RagdollGrabbableObject
attachedGrabbableObject
hive
RemoteProp
component
component
ShotgunItem
Shovel
SprayPaintItem
component
component
targetingMetalObject
setStaticGrabbableObject
component
StunGrenadeItem
TetraChemicalItem
WalkieTalkie
WhoopieCushionItem
currentlyHeldObject
currentlyGrabbingObject
currentlyHeldObjectServer
pocketedFlashlight
component
component
grabbableObject
grabbableObject
grabbableObject
component2
```

#### Method2

Decompiling the `Lethal Company.exe` to get every class/var which is `GrabbableObject` with ILSpy.

1. Download the [ILSpy](https://github.com/icsharpcode/ILSpy) with Visual Studio(it may take 30min~ if you don't have both of them).
2. Build and open the ILSpy GUI.
4. Open Steam and right click the Lethal Company to get your game's file directory.
5. Open the file `Assembly-CSharp.dll` which may in the path like `~\Steam\steamapps\common\Lethal Company\Lethal Company_Data\Managed\Assembly-CSharp.dll`.
6. Export the C# code of `Assembly-CSharp.dll`.
7. Open the C# project `Assembly-CSharp.cspj` in Visual Studio.
8. Search the class or variable which belongs `GrabbableObject` with eyes haha.
