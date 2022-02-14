# 流浪文明•逃逸 简单游戏架构分析

by 打杂的8

> 完全基于《流浪文明•逃逸》先期策划案 by 张量子

> 纯个人见解，有问题或建议可以指出

## 资源管理

初步估计，本游戏美术资源主要包括人物贴图，物品贴图，地形贴图三类，此外还有文本资源与音乐资源

### **人物**

游戏中出现人物数量有限且极少，直接使用GameObject做好Prefab就行了，挂载统一的人物脚本组件

```c#
public class Character: MonoBehaviour
{
    public string name;
    pubilc float speed;
    //(other fields)
    pubilc void Walk(int foward){}/*由控制器调用*/
    pubilc void OnWalk(){}/*由游戏主更新器调用*/
    public void Damaged(float DamagedValue){}
    //(other methods)
}
```

### **物品**

使用一个单例物品贴图管理器来实时返回需要的sprite，通过预定义的表格加载AssetsBundle中的Sprite资源

```c#
public class ItemSpriteManager: Singlon<ItemSpriteManager>
{
    //(fields)
    void LoadSpriteFromAssetsBundle(){}
    public Sprite GetItemSprite(int itemId){}
    //(other methods)
}

```

在各种游戏事件/GUI中直接调用ID获取贴图

### **地形贴图**

地形贴图分为两类，不可破坏的墙壁、地板等等可以直接写在GameObject中

可破坏的地形通过触发游戏事件播放动画、更换贴图实现，因为地形种类较少且固定，同样直接写在场景的GameObject中

地下城和小镇放在同一场景中，用改变摄像机实现进出

### **文本资源**

处理方法类似**物品**，使用一个单例文本管理器，便于进行本地化（？），虽然我不认为这个游戏会出外语版本。
```c#
public class TextsManager: Singlon<TextsManager>
{
    ArrayList strings;
    HashSet<Text> gameTexts;
    string nowLangauge = "zh-cn"; 
    //(other fields)
    void LoadStringFromAssetsBundle(string langauge = "zh-cn"){}
    public void RegisterText(Text text, int stringId)
    {
        text.text = strings[stringId];
        if (!gameText.Contains(text)) gameTexts.Add(text);
    }
    public void ChooseLanguage(string langauge)
    {
        if (langauge != nowLangauge)//重新加载语言包
        LoadStringFromAssetsBundle(langauge);
    }
    //(other methods)
}

```

### **音乐资源**

使用一个单例音乐播放器，储存并播放音乐

```c#
public class MusicManager: Singlon<MusicManager>
{
    //(fields)
    void LoadMusicFromAssetsBundle()
    public void ChooseMusic(int musicID){}
    //(other methods)
}
```
音效，对话也通过类似的接口实现,不再重复

## 游戏输入控制器

使用一个单例，管理来自键盘的输入，并且
```c#
public class GameController: Singlon<GameController>
{
    //(fields)
    public void OnUpdate()/*由游戏主更新器调用*/
    {
        //一个示意，通过实时获取操作的按键来实现操作改键
        if (Input.GetKey(KeycodeManager.Instance.GetKeycode("HeroWalkLeft"))
        {
            Hero.Walk(-1);    
        }
        // ......
    }
}
```
```c#
public class KeycodeManager: Singlon<KeycodeManager>
{
    //(fields)
    public int GetKeycode(string operationName){}
    public void SetKeycode(string operationName, int newkeycode){}

}
```
## GUI控制器

一个控制器，根据需要显示各种预先绘制好的框体

## 游戏事件

考虑到规模不大且没有二次开发需求，所有事件都单独写脚本，统一继承基本事件类GameEvent

GameEvent作为一个脚本组件挂载在所有对话，可拾取道具，各种意外等等事件上

基类:
```c# 
public class GameEvent: MonoBehaviour
```


## 游戏流程控制器

游戏的主脚本，控制背包，时间和各种游戏事件的已触发情况，同时实现游戏的保存和加载

## 游戏主更新器

调用所有需要放在MonoBehaviour.Update()或者MonoBehaviour.FixedUpdate()中的内容，以便控制时序

```c#
void Update()
{
    //...
    foreach(Character nowCharacter in activeCharacters)
    {
        nowCharacter.OnWalk();
        //(other invokes)
    }
    //...
}
```