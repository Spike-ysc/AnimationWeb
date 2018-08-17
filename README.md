# AnimationWeb
动画电影主题网站（ASP.NET）
========================
* ## 1、系统功能说明<br/>

    项目设计的是关于动画电影的网站，网站为ASP.NET MVC项目。页面主要采用Bootstrap框架。使用SQL Server Express LocalDB数据库。并加入了jQuery、Echarts、Ajax以及其他CSS特效。<br/>
    网站分为新闻模块、作品模块、主题模块、用户管理模块和登录注册模块共五个模块<br/>
    新闻模块：新闻模块分为四个部分。用户点击左侧导航栏切换。使用Ajax局部刷新新闻内容。根据数据库内容加载新闻。<br/>
    作品模块：以动画导演划分作品。用户点击跳转不同页面。页面未使用数据库<br/>
    主题模块：主题模块是对不同主题的作品的简介。未使用数据库。<br/>
    用户管理模块：分为几个模块。点击左侧导航局部刷新切换。提供显示用户信息。增删改查功能。数据库操作部分使用LINQ to Entities和系统生成的更改信息功能。使用Echarts显示图表信息。图表数据为固定数据。<br/>
    登录注册模块：采用LINQ连接数据库。使用jquery进行验证。对登录数据进行验证和处理。实现登录、注册、更改密码功能。更改密码不需要验证。<br/>

* ## 2、操作步骤

    普通用户进入网站可以在首页上浏览相关模块的精选介绍。点击链接可以查看具体内容。也可以通过顶部的导航栏浏览各个模块。<br/>
    新闻模块：用户可以通过左侧导航栏选择新闻类型。点击新闻查看具体信息。<br/>
    作品模块：以动画导演划分不同的作品。用户可以根据导演查看相应的动画电影作品。点击作品可以查看详细的作品介绍。<br/>
    主题模块：主题模块是对不同主题的作品的简介。用户可以点击感兴趣的主题查看内容。<br/>
    用户管理模块：进入用户管理模块时。需要验证是否为管理员。管理员可以在用户管理模块查看用户注册信息。实现用户的增删改查功能。并且可以以图表的格式查看当前网站的部分信息。<br/>
    登录注册模块：用户可以在此模块操作登录注册以及更改密码的功能<br/>

* ## 3、项目截图

    ### 用户管理页面
    ![](https://github.com/Spike-ysc/AnimationWeb/raw/master/AnimationWeb/Images/用户管理.png)
    
    ### 新闻页面
    ![](https://github.com/Spike-ysc/AnimationWeb/raw/master/AnimationWeb/Images/新闻.png)
    
    ### 登录注册页面
    ![](https://github.com/Spike-ysc/AnimationWeb/raw/master/AnimationWeb/Images/登录注册.png)
    
    ### 主题页面
    ![](https://github.com/Spike-ysc/AnimationWeb/raw/master/AnimationWeb/Images/主题.png)
    
    ### 作品页面
    ![](https://github.com/Spike-ysc/AnimationWeb/raw/master/AnimationWeb/Images/作品.png)
    
    ### 首页页面
    ![](https://github.com/Spike-ysc/AnimationWeb/raw/master/AnimationWeb/Images/首页.png)
