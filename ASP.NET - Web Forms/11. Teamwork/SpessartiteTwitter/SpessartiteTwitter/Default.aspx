<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SpessartiteTwitter._Default" %>

<%@ Register Src="~/Controls/Twitter/Twitter.ascx" TagName="Twitter" TagPrefix="userControls" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Welcome</h1>
        <hr />
        <userControls:Twitter runat="server" ID="TwitterPanel" />
    </div>
</asp:Content>
































 <%--        <asp:ListView ID="LatestTweetsListView" runat="server"
            SelectMethod="LatestTweetsListView_GetLatestTweets"
            ItemType="SpessartiteTwitter.Data.Tweet"
            DataKeyNames="TweetId">

            <ItemTemplate>
                <div class="alert alert-info alert-block home-tweet-item">
                    <h4>
                        <a href="TweetDetails.aspx?TweetId=<%# Item.TweetId %>">
                            <%#: Item.TweetTitle %>
                        </a>
                        <small>(<%# Item.Comments.Count %>) comments
                        </small>
                    </h4>

                    <p>
                        <%#: Item.TweetText.ToString().Substring(0, Math.Min(255, Item.TweetText.Length)) + "... " %>
                        <a href="TweetDetails.aspx?TweetId=<%# Item.TweetId %>">
                            <small>Details</small>
                        </a>
                    </p>
                    <p>
                        by
                        <strong>
                            <asp:HyperLink NavigateUrl='<%# "~/User/UserDetails.aspx?Username=" + Item.AspNetUser.UserName %>' runat="server" Text="<%#: Item.AspNetUser.UserName %>"/>
                        </strong>
                        on
                        <asp:Literal runat="server" ID="TimePosted" Text="<%#: GetPostedTime(Item.DatePosted) %>"></asp:Literal>

                    </p>
                </div>
            </ItemTemplate>
        </asp:ListView>

        <asp:DataPager ID="LatestTweetsDataPager" runat="server"
            PagedControlID="LatestTweetsListView"
            PageSize="4">
            <Fields>
                <asp:NextPreviousPagerField ShowNextPageButton="true" NextPageText="Previous" ShowPreviousPageButton="true" PreviousPageText="Next" ButtonCssClass="btn btn-info" />
            </Fields>
        </asp:DataPager>--%>