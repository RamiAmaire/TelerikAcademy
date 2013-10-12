<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTweet.aspx.cs" Inherits="SpessartiteTwitter.Registered.EditTweet" %>

<asp:Content ID="ContentEditTweet" ContentPlaceHolderID="MainContent" runat="server">

    <div id="edit-tweet-container">

        <h3>Edit Tweet:</h3>
        <span>Title:    </span>
        <asp:TextBox ID="TextBoxTitle" runat="server" />
        <br />
        <span>Tweet:</span>
        <asp:TextBox ID="TextBoxText" runat="server" TextMode="MultiLine" Columns="50" Rows="5" />
        <br />
        <span>Date:</span>
        <asp:TextBox ID="TextBoxDate" runat="server" TextMode="Date" />
        <br />
        <span>Upload picture:</span>
        <asp:FileUpload runat="server" ID="ProfilePictureFileUpload" />
        <br />
        <hr />

        <h3>Comments:</h3>

        <ul>
            <asp:Repeater runat="server" ID="RepeaterComments" ItemType="SpessartiteTwitter.Data.Comment">
                <ItemTemplate>
                    <li>
                        <%#: Item.CommentText %>
                        <a href="EditComment.aspx?commentId=<%# Item.CommentId %>">Edit</a>
                        <asp:LinkButton Text="Delete" runat="server"
                            CommandName="Delete"
                            CommandArgument="<%# Item.CommentId %>"
                            OnCommand="DeleteComment_Command" />
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

        <br />
        <asp:LinkButton ID="LinkButtonSave" runat="server" Text="Save" OnClick="LinkButtonSave_Click" />
        <asp:LinkButton ID="LinkButtonCancel" runat="server" Text="Cancel" OnClick="LinkButtonCancel_Click" />

    </div>

</asp:Content>
