# Lethal Company ItemName List


### Motivation

When people who don't know programming want to add/delete item in the mod's config, they are confused what item name should use.

### How to get Item List

I decompile the decompile the `Lethal Company.exe` to get every class which is `GrabbableObject` with ILSpy.

1. Download the [ILSpy](https://github.com/icsharpcode/ILSpy) with Visual Studio (it may take 30min~ if you don't have both of them).
2. Build and open the ILSpy GUI.
4. Open Steam and right click the Lethal Company to get your game file directory.
5. Open the file `Assembly-CSharp.dll` which may in the path like `~\Steam\steamapps\common\Lethal Company\Lethal Company_Data\Managed\Assembly-CSharp.dll`.
6. Export the C# code of `Assembly-CSharp.dll`.
7. Open the C# project `Assembly-CSharp.cspj` in Visual Studio.
8. Search the class or variable which is `GrabbableObject`.

I am searching a new method that can automatically and easily get the items' name and their `class`. If anyone has a better method, I'm all ears.

### Item List

**In my speculation**, there may be several items classified under the same category. For example, both a regular Flashlight and a Pro Flashlight are defined within the `FlashlightItem` category. This is why some items have the suffix 'Item' while others do not.

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

This list is internal variable in some object, but they are also `GrabbableObject`. If anyone has tried below item name and know it is useful or not, pls tell me.

| Item Name | Trad.CH |
|---|---|
|focusedScrap|集中的廢棄物|
|heldScrap|持有的廢棄物|
|grabBodyObject|抓取大體|
|pocketedFlashlight|放入口袋的手電筒|
|attachedGrabbableObject|附著的可抓取物體|
|hive|蜂巢|
