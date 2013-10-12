<%@ Page Title="Tweet Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TweetDetails.aspx.cs" Inherits="SpessartiteTwitter.TweetDetails" %>

<asp:Content ID="ContentTweetDetails" ContentPlaceHolderID="MainContent" runat="server">

    <div id="tweetPage">
        <asp:FormView runat="server" ID="FormViewTweetDetails"
            ItemType="SpessartiteTwitter.Data.Tweet" SelectMethod="FormViewTweetDetails_GetItem">
            <HeaderTemplate>
                <div class="tweet-title"><%#: Item.TweetTitle %></div>
            </HeaderTemplate>
            <ItemTemplate>
                <img class="img-rounded" width="200" height="200" src="<%#: Item.Image != null ? "data:image/png;base64," + Convert.ToBase64String(Item.Image) : "" %>" alt="<%#: Item.TweetTitle %>" />
                <div class="tweet-text"><%#: Item.TweetText %></div>
            </ItemTemplate>
            <FooterTemplate>
                <div class="tweet-footer">
                    Posted on : <%#: Item.DatePosted %>, by : <%#: Item.AspNetUser.UserName %>
                </div>
            </FooterTemplate>
        </asp:FormView>
    </div>

    <asp:UpdatePanel runat="server" ID="TweetDetailsCommentsUpdatePanel">
        <ContentTemplate>
            <div id="CommentBoxHolder" runat="server">
                <fieldset id="FieldSetAddComment" runat="server">
                    <legend runat="server">Add comment</legend>
                    <asp:TextBox ID="CommentText" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <asp:Button ID="ButtonAddComment" Text="Add comment"
                        runat="server" OnClick="ButtonAddComment_Click" />
                    <%--                    <asp:Button ID="ButtonCancelComment" Text="Cancel"
                        runat="server" OnClick="ButtonCancelComment_Click" />--%>
                </fieldset>
            </div>

            <div id="CommentsHolder" runat="server">
                <h4>Comments</h4>
                <ul runat="server">
                    <asp:ListView ID="ListViewTweetComments" DataKeyNames="CommentId"
                        SelectMethod="ListViewTweetComments_GetData" runat="server"
                        ItemType="SpessartiteTwitter.Data.Comment">
                        <ItemTemplate>
                            <li runat="server">
                                <div class="comment-text" runat="server"><%#: Item.CommentText %></div>
                                <div class="comment-footer" runat="server">
                                    Posted on : <%#: Item.DatePosted %>,
                             by : <a runat="server" href='<%# string.Format("~/UserDetails.aspx?Username={0}", Item.AspNetUser.UserName)%>'>
                                 <%#: Item.AspNetUser.UserName %></a>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:ListView>
                </ul>

                <asp:DataPager ID="DataPagerComments" runat="server" PagedControlID="ListViewTweetComments"
                    PageSize="3">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" ButtonCssClass="btn btn-info" />
                        <asp:NumericPagerField NumericButtonCssClass="btn btn-info" />
                        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" ButtonCssClass="btn btn-info" />
                    </Fields>
                </asp:DataPager>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
