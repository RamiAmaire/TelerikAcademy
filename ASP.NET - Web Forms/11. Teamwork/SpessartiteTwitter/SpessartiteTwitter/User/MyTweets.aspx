<%@ Page Title="My Tweets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyTweets.aspx.cs" Inherits="SpessartiteTwitter.Registered.MyTweets" %>

<%@ Register Src="~/Controls/Twitter/Twitter.ascx" TagName="Twitter"
    TagPrefix="userControls" %>

<asp:Content ID="ContentMyTweets" ContentPlaceHolderID="MainContent" runat="server">

    <h1>My Tweets</h1>
    <hr />
    <userControls:Twitter runat="server" ID="TwitterPanel" />

</asp:Content>
