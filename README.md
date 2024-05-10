# 大吉大利 今晚抽签
## 基于 .NET MAUI 的跨平台随机抽签程序



### 概述
本产品是一款基于 .NET MAUI 技术架构所开发的跨平台随机抽签程序。

本产品的开发目的是为了便利于学校的课堂提问、活动抽人以及其它各项需要使用随机点人的场景，为主办者提供一个便捷、公平、可依据的应用程序。

本产品选用 .NET MAUI 作为开发框架，是本人对 .NET MAUI 的第一次尝试，也是我对于 .NET 学习上的一个试验品。

本产品正在参加学校的一个比赛，希望能够得到评委老师们的青睐吧。


### 使用方式
#### 开发环境
请确保您的计算机安装以下环境：

- Windows 10 或 Windows 11 操作系统
- .NET SDK 7.0
- .NET SDK 中的 MAUI 开发工作负载
- Git
- Android SDK
- Visual Studio 2022
        
此外，本项目使用了 NuGet 包进行拓展开发，请在克隆本项目到计算机并打开后自行下载 ```CommunityToolkit.Maui```。
    
#### 应用调试和部署
1. 使用 Git 将本项目 Clone 到你的计算机上
2. 双击打开位于 ```AVENTURINECOIN_MAUIEDITION``` 目录下的解决方案文件。
3. 如果没有错误，在 Visual Studio 中显示的该解决方案下应该包含三个项目文件，即 ```AVENTURINECOIN_MAUIEDITION```、```AMClassLibrary``` 以及 ```AMClassLibraryForSave```。
4. 在 **调试/运行** 按钮的下拉菜单中选择您想要进行调试的调试平台（对于要进行 Android 和 iOS 部署的，建议将实体设备打开“开发者模式”和“允许USB调试”后通过数据线连接至电脑，选择“本地设备”进行部署调试）
5. 应用启动后可以点击选项卡选择功能进行调试。
    
### 应用功能
1. **单人抽取**
一次抽取一位名单中的记录
2. **多人抽取**
一次抽取多位名单中的记录，抽取数由用户输入
3. **名单设置**
由用户设置进行抽取的名单
4. **抽取记录**
读取、管理每次抽取的结果和记录

<img src="Windows-Prev.jpg" width="350">
<img src="Android-Prev.jpg" height="250">

### 技术架构
.[NET 7.0](https://dotnet.microsoft.com)
.[NET MAUI 7.0](https://learn.microsoft.com/zh-cn/dotnet/maui/?view=net-maui-7.0&WT.mc_id=dotnet-35129-website)
    
### 可能存在的问题
因为时间紧迫和条件限制，我们只在 Windows 和 Android 上进行了大部分的软件功能的测试。面对在 Apple 产品上运行的情况以及其它可能未被查觉的错误情况，欢迎大家向我们提出 Issue 报告错误。
    
### 发行说明
本产品基于 MIT 协议进行免费的开放源代码模式发行。
    
    开发代号：AVENTURINECOIN
    版本：MAUI EDITION
    版本号：1.0.0
    开发阶段：Alpha
    适用平台：Windows、Android、iOS、MacOS
    
### 开发人员和团队
**SPGLP（超级古力怕55）**
即本仓库的创建者和所有者，负责本项目的主要开发工作、管理和文档的编写。是本项目的主要负责人。
    
**GJMofeng**
负责本项目的文档编写和辅助开发工作
    
**Chaoix**
负责本项目UI的辅助设计工作。

**Velpros**
负责本项目的项目管理、版本控制辅助工作。
    
### 贡献方式
查看 Issue 上的漏洞报告，或提出 Issue 说明你的想法或改进策略。Fork本仓库，新建分支为 ```Feature/<用户名>/<修改内容简述>```，通过拉取（合并）请求向我们提交您的更改。
    
我们十分感谢和欢迎您的无私奉献和不吝赐教。