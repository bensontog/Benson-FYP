<%@ Page Title="One-Stop Fraud Reporting System - Home" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OneStopFraudReportingSystem.WebForm4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="title" runat="server">

    <asp:PlaceHolder ID="welcome" runat="server"></asp:PlaceHolder>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">
    <style>
        /*Slideshow container*/
        .slideshow-container{
            max-width: 1000px;
            position: relative;
            margin: auto;
        }

        /*Cpation text*/
        .text{
            color: #f2f2f2;
            font-size: 15px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
        }

        /*Number text (1/3 etc)*/
        .numbertext{
            color: #f2f2f2;
            font-size: 12px;
            padding: 8px 12px;
            position: absolute;
            top: 0;
        }

        /*The dots/bullets/indicators*/
        .dot{
            height: 15px;
            width: 15px;
            margin: 0 2px;
            background-color: #bbb;
            border-radius: 50%;
            display: inline-block;
            transition: background-color 0.6s ease;
        }

        .active{
            background-color: #717171;
        }

        /*Fading animation*/
        .fade{
            -webkit-animation-name: fade;
            -webkit-animation-duration: 1.5s;
            animation-name: fade;
            animation-duration: 1.5s;
        }

        @-webkit-keyframes fade{
            from{opacity: .4}
            to{opacity: 1}
        }

        @keyframes fade{
            from{opacity: .4}
            to{opacity: 1}
        }

        /*On smaller screens, descrease text size*/
        @media only screen and (max-width: 300px){
            .text {font-size: 11px}
        }

        .inline-photo{
            border: 1em solid #fff;
            border-bottom: 4em solid #fff;
            border-radius: .25em;
            box-shadow: 1em 1em 2em .25em rgba(0,0,0,.2);
            margin: 2em auto;
            opacity: 0;
            transform: translateY(4em) rotateZ(-5deg);
            transition: transform 4s .25s cubic-bezier(0,1,.3,1),
                        opacity .3s .25s ease-out;
            max-width: 600px;
            width: 450px;
            height:400px;
            will-change: transform, opacity;
        }

        .inline-photo.is-visible {
          opacity: 1;
          transform: rotateZ(-2deg);
        }

        .column {
            float: left;
            width: 33.3%;
            margin-bottom: 16px;
            padding: 0 8px;
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
        }

        .card {
          box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
          margin: 6px;
        }

        .about-section {
          padding: 50px;
          text-align: center;
          background-color: #474e5d;
          color: white;
        }

        .container {
            background-color: white;
            border: 1px solid black;
            width: 300px;
            height: 200px;
            margin: auto;
            padding: 1em;
            text-align: center;
        }

        .container::after, .row::after {
          content: "";
          clear: both;
          display: table;
        }

        .title {
          color: grey;
        }

         @media screen and (max-width: 650px) {
          .column {
            width: 100%;
            display: block;
          }
        }

    </style>

    <div class="slideshow-container">
        <div class="mySlides fade">
            <div class="numbertext"></div>
            <img src="Images/Poster/poster-2.png" style="width:1000px;height:550px"/>
        </div>

        <div class="mySlides fade">
            <div class="numbertext"></div>
            <img src="Images/Poster/poster-1.jpg" style="width:1000px;height:550px"/>
        </div>

        <div class="mySlides fade">
            <div class="numbertext"></div>
            <img src="Images/Poster/poster-3.jpg" style="width:1000px;height:550px"/>
        </div>

        <div class="mySlides fade">
            <div class="numbertext"></div>
            <img src="Images/Poster/poster-4.jpg" style="width:1000px;height:550px"/>
        </div>

    </div>

    <br />

    <div style="text-align:center">
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
        <span class="dot"></span>
    </div>

    <br />
    <br />

    <asp:PlaceHolder ID="contentAd" runat="server"></asp:PlaceHolder>

    <header class="card-header show-on-scroll">
        <div class="main-photo"></div>
        <h1 class="heading" style="text-align:center;">About Us</h1>
    </header>

    <article class="content" style="text-align:center">
        <img src="Images/companyLogo.png" class="inline-photo show-on-scroll"/>

        <h4>One-Stop Fraud Reporting Platform was a platform that allow all the victim of fraud cases to make their reporting at the first instance.</h4>  
        
        <br />
    </article>

    <header class="card-header show-on-scroll">
        <div class="main-photo"></div>
        <h1 class="heading" style="text-align:center;">Our Features</h1>
    </header>

    <article class="content" style="text-align:center">
        <img src="Images/message-identify.jpg" class="inline-photo show-on-scroll"/>
        <h3><strong>Message Identification</strong></h3>
        <h4>Help the user to identify the text message that received.</h4>

        <img src="Images/addReport.png" class="inline-photo show-on-scroll"/>
        <h3><strong>Cases Reporting</strong></h3>
        <h4>Allow the user to make reporting for the fraud cases that encountered.</h4>
    </article>

    

    <script>
        var slideIndex = 0;
        showSlides();

        function showSlides() {
            var i;
            var slides = document.getElementsByClassName("mySlides");
            var dots = document.getElementsByClassName("dot");
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > slides.length) { slideIndex = 1 }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " active";
            setTimeout(showSlides, 2000);
        }

        var scroll = window.requestAnimationFrame ||
            function (callback) { window.setTimeout(callback, 1000 / 60) };
        var elementsToShow = document.querySelectorAll('.show-on-scroll');

        function loop() {

            Array.prototype.forEach.call(elementsToShow, function (element) {
                if (isElementInViewport(element)) {
                    element.classList.add('is-visible');
                } else {
                    element.classList.remove('is-visible');
                }
            });

            scroll(loop);
        }

        loop();

        function isElementInViewport(el) {
            if (typeof jQuery === "function" && el instanceof jQuery) {
                el = el[0];
            }
            var rect = el.getBoundingClientRect();
            return (
                (rect.top <= 0
                    && rect.bottom >= 0)
                ||
                (rect.bottom >= (window.innerHeight || document.documentElement.clientHeight) &&
                    rect.top <= (window.innerHeight || document.documentElement.clientHeight))
                ||
                (rect.top >= 0 &&
                    rect.bottom <= (window.innerHeight || document.documentElement.clientHeight))
            );
        }
    </script>

</asp:Content>
