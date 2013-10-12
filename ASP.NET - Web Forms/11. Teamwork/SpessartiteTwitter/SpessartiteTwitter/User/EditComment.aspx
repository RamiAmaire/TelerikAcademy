<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditComment.aspx.cs" Inherits="SpessartiteTwitter.Registered.EditComment" %>

<asp:Content ID="ContentEditComment" ContentPlaceHolderID="MainContent" runat="server">

    <div id="edit-comment-container">
        <h3>Edit Comment:</h3>
        <br />
        <span>Comment:</span>
        <asp:TextBox ID="TextBoxText" runat="server" TextMode="MultiLine" Columns="50" Rows="5" />
        <br />
        <span>Date:</span>
        <asp:TextBox ID="TextBoxDate" runat="server" TextMode="Date" />
        <br />
        <asp:LinkButton ID="LinkButtonSave" runat="server" Text="Save" OnClick="LinkButtonSave_Click" />
        <asp:LinkButton ID="LinkButtonCancel" runat="server" Text="Cancel" OnClick="LinkButtonCancel_Click" />
    </div>

</asp:Content>
