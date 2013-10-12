<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SpessartiteTwitter.Users" %>

<asp:Content ID="ContentUsersAdministration" ContentPlaceHolderID="MainContent" runat="server">
    <div id="grid-view-users">
        <h3 id="h2-users-administration">Users Administration</h3>
        <asp:GridView ID="GridViewUsers" runat="server"
            AutoGenerateColumns="false"
            AllowPaging="true"
            PageSize="4"
            AllowSorting="true"
            SelectMethod="GridViewUsers_GetData"
            DataKeyNames="Id"
            OnSelectedIndexChanged="GridViewUsers_SelectedIndexChanged">

            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                <asp:BoundField DataField="MobilePhone" HeaderText="Mobile Phone" SortExpression="MobilePhone" />
                <asp:BoundField DataField="WebSite" HeaderText="Web Site" SortExpression="WebSite" />
                <asp:BoundField DataField="Skype" HeaderText="Skype" SortExpression="Skype" />
                <asp:BoundField DataField="Facebook" HeaderText="Facebook" SortExpression="Facebook" />
                <asp:HyperLinkField Text="Edit" HeaderText="Edit"
                    DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/User/Settings.aspx?userId={0}" />
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
