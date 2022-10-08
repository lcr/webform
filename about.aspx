<%@ Page Language="C#" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport"
        content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <title>About</title>
    <link href="../css/public.css" rel="stylesheet" type="text/css" />
    <link href="../css/about.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="slideshow-container">
        <div class="slideShowImg">
            <img src="../img/img_nature_wide.jpg" />
        </div>
        <div class="slideShowImg">
            <img src="../img/img_snow_wide.jpg" />
        </div>
        <div class="slideShowImg">
            <img src="../img/img_mountains_wide.jpg" />
        </div>
        <div class="slideShowImg">
            <img src="../img/img_lights_wide.jpg" />
        </div>
        <div class="slideShowImg">
            <img src="../img/img_woods_wide.jpg" />
        </div>
        <div class="slideshow-dot-cantainer">
            <span class="slideShowDot"></span>
            <span class="slideShowDot"></span>
            <span class="slideShowDot"></span>
            <span class="slideShowDot"></span>
            <span class="slideShowDot"></span>
        </div>
    </div>


    <nav class="nav">
        <a href="index.aspx">首页</a>
        <a href="info_show/list.aspx?class_name=繁中假字">繁中假字</a>
        <a href="about.aspx" class="nav-active">关于我们</a>
    </nav>


    <div class="page-about-content">
        <p>
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aspernatur atque aut autem culpa debitis expedita illo
    inventore labore, non rerum sapiente sunt voluptatum? Eligendi exercitationem laborum non numquam, possimus
    quam.
        </p>
        <p>
            Ducimus eius iusto laudantium nisi optio quam qui recusandae, temporibus! Asperiores delectus
    dignissimos dolores enim ex illum, impedit, labore magnam maxime molestias necessitatibus quisquam quod rem repellat
    sint sunt tempore?
        </p>
        <p>
            Architecto, corporis cumque deleniti eos fugiat ipsum labore modi molestiae odit
    repellendus sapiente similique sunt. Cupiditate exercitationem odio unde. Aut cum cumque eius nemo, quod saepe
    soluta suscipit veritatis voluptatum.
        </p>
        <p>
            Error facere magni mollitia tempore. Asperiores aspernatur aut
    consectetur, dolor dolorem doloribus eligendi et eveniet facilis fugiat ipsam natus nisi optio pariatur quidem
    ratione reiciendis repellat sequi similique velit voluptate!
        </p>
    </div>
    <footer>
        <p>©2022 All Rights Reserved</p>
    </footer>
    <script src="js/sideshow.js"></script>

</body>
</html>
