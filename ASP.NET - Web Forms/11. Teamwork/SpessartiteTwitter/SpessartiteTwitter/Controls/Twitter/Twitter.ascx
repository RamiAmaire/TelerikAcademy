<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="Twitter.ascx.cs"
    Inherits="SpessartiteTwitter.Controls.Twitter.Twitter" %>

<asp:UpdatePanel runat="server" ID="UpdatePanelTweets">
    <ContentTemplate>
        <asp:ListView ID="TweetsListView" runat="server"
            DataKeyNames="TweetId"
            SelectMethod="GetTweets"
            InsertItemPosition="FirstItem"
            ItemType="SpessartiteTwitter.Data.Tweet"
            OnDataBound="TweetsListView_DataBound"
            DeleteMethod="TweetsListView_DeleteItem"
            InsertMethod="TweetsListView_InsertItem">

            <ItemTemplate>
                <div class="alert alert-info alert-block tweet-item">
                    <h4>
                        <asp:HyperLink runat="server"
                            Text="<%#: Item.TweetTitle %>"
                            NavigateUrl='<%# "~/TweetDetails.aspx?TweetId="+Item.TweetId %>' />
                        <small>(<%# Item.Comments.Count %>) comments</small>
                    </h4>

                    <p>
                        <%#: Item.TweetText.ToString().Substring(0, Math.Min(255, Item.TweetText.Length)) + "... " %>
                        <asp:HyperLink runat="server"
                            Text="Details"
                            NavigateUrl='<%# "~/TweetDetails.aspx?TweetId="+Item.TweetId %>' />
                    </p>

                    <p>
                        by 
                        <asp:HyperLink ID="UserProfileHyperLink" runat="server"
                            Text="<%# Item.AspNetUser.UserName %>"
                            NavigateUrl='<%# "~/UserDetails.aspx?Username=" + Item.AspNetUser.UserName %>' />
                        on
                        <asp:Literal runat="server" ID="TimePosted"
                            Text="<%#: GetPostedTime(Item.DatePosted) %>" />
                    </p>

                    <asp:HyperLink ID="LinkButtonEditTweet" runat="server"
                        Text="Edit" 
                        NavigateUrl='<%#: "~/User/EditTweet.aspx?tweetId=" + Item.TweetId %>' />
                    <asp:LinkButton ID="LinkButtonDeleteTweet" runat="server"
                        Text="Delete"
                        CommandName="Delete"
                        CommandArgument="<%# Item.TweetId %>"
                        OnClientClick="return confirm('Are you sure deleting this Tweet ?');" />
                </div>
            </ItemTemplate>

            <InsertItemTemplate>
                <div class="row">
                    <div class="well" style="margin-left: 30px">
                        <asp:TextBox runat="server" ID="TweetTitleTb" CssClass="span4" placeholder="Tweet Title" />
                        <asp:TextBox runat="server" ID="TweetTextTb" TextMode="MultiLine" style="width: 100%" Rows="2" placeholder="Tweet Content" />
                        <br />
                        <div id="newTweetError" class="alert alert-error" style="display: none"></div>
                        <asp:LinkButton ID="LinkButtonCreateTweet" runat="server"
                            CssClass="btn btn-info"
                            CommandName="Insert"
                            Text="Post New Tweet" />

                        <div class="update-progress">
                            <asp:UpdateProgress ID="TweetsBottomUpdateProgress" runat="server"
                                AssociatedUpdatePanelID="UpdatePanelTweets">
                                <ProgressTemplate >
                                    <asp:Image ImageUrl="~/Images/ajax-loader.gif" runat="server" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>

                        <h6 id="charsRemaining" class="pull-right">2000 characters remaining</h6>
                    </div>
                </div>
                <hr />
                <p class="lead">Latest Tweets</p>
            </InsertItemTemplate>
        </asp:ListView>

        <asp:DataPager ID="TweetsDataPager" runat="server"
            PagedControlID="TweetsListView"
            PageSize="4"
            Visible="false">
            <Fields>
                <asp:NextPreviousPagerField
                    ShowNextPageButton="true"
                    NextPageText="Previous"
                    ShowPreviousPageButton="true"
                    PreviousPageText="Next"
                    ButtonCssClass="btn btn-info" />
            </Fields>
        </asp:DataPager>

        <div class="update-progress">
            <asp:UpdateProgress ID="TweetsBottomUpdateProgress" runat="server"
                AssociatedUpdatePanelID="UpdatePanelTweets">
                <ProgressTemplate >
                    <asp:Image ImageUrl="~/Images/ajax-loader.gif" runat="server" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<script>
    function pageLoad(sender, args) {
        var charsRemaining = $('#charsRemaining'),
            error = $('#newTweetError'),
            title = $('#MainContent_TwitterPanel_TweetsListView_TweetTitleTb'),
            content = $('#MainContent_TwitterPanel_TweetsListView_TweetTextTb'),
            submit = $('#MainContent_TwitterPanel_TweetsListView_LinkButtonCreateTweet'),
            updatePanel = $('#MainContent_TwitterPanel_UpdatePanelTweets');

        if (args.get_isPartialLoad()) {
            updatePanel.on('keydown keypress', '#MainContent_TwitterPanel_TweetsListView_TweetTextTb', setRemainingChars);
            updatePanel.on('click', '#MainContent_TwitterPanel_TweetsListView_LinkButtonCreateTweet', handleSubmitClick);
        } else {
            updatePanel.on('mouseenter', '.tweet-item', showErrorAlert);
            updatePanel.on('mouseleave', '.tweet-item', hideErrorAlert);
            updatePanel.on('keydown keypress', '#MainContent_TwitterPanel_TweetsListView_TweetTextTb', setRemainingChars);
            updatePanel.on('click', '#MainContent_TwitterPanel_TweetsListView_LinkButtonCreateTweet', handleSubmitClick);
        }

        function showErrorAlert() {
            $(this)
                .removeClass('alert-info')
                .addClass('alert-success');
        };

        function hideErrorAlert() {
            $(this)
                .removeClass('alert-success')
                .addClass('alert-info');
        };

        function setRemainingChars() {
            var charsLeft = 2000 - content.val().length,
                remainingMessage = charsLeft + '  characters remaining';

            charsRemaining.text(remainingMessage);
        };

        function handleSubmitClick(event) {
            error.text("").hide();

            var titleLen = title.val().length,
                contentLen = content.val().length;

            if (titleLen < 6 || titleLen > 200) {
                event.preventDefault();
                error
                    .text("Title's fucking problem")
                    .show(200);
            } else if (contentLen < 6 || contentLen > 2000) {
                event.preventDefault();
                error
                    .text("Content's fucking problem")
                    .show(200);
            }
        };
    }
</script>
