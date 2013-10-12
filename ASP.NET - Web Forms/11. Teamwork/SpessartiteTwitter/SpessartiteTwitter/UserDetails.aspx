<%@ Page Title="User Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="SpessartiteTwitter.UserDetails" %>

<%@ Register Src="~/Controls/Twitter/Twitter.ascx" TagName="Twitter"
    TagPrefix="userControls" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="span3">
            <asp:FormView ID="FormView1" runat="server"
                SelectMethod="UserDetailsFormView_GetUserInfo"
                ItemType="SpessartiteTwitter.Data.AspNetUser"
                DataKeyNames="Id"
                DefaultMode="ReadOnly">
                <ItemTemplate>
                    <img class="img-rounded" width="200" height="200" src="<%#: Item.Picture != null ? "data:image/png;base64," + Convert.ToBase64String(Item.Picture) : "Images/profile_placeholder.gif" %>" alt="<%#: Item.UserName + "'s profile picture" %>" />
                    <div class="caption">
                        <h3><%#: Item.UserName %></h3>
                        <p><%#: Item.FirstName != null || Item.LastName != null ? "Name: " + Item.FirstName + " " + Item.LastName : string.Empty %></p>
                        <p><%#: Item.Age != null ? "Age: " + Item.Age : string.Empty %></p>
                        <p><%#: Item.AboutMe != null ? "About me: " + Item.AboutMe : string.Empty %></p>
                        <p><%#: Item.WebSite != null ? "WebSite: " + Item.WebSite : string.Empty %></p>
                        <p><%#: Item.MobilePhone != null ? "MobilePhone: " + Item.MobilePhone : string.Empty %></p>
                        <p>
                            <asp:HyperLink NavigateUrl='<%# "skype:" + Item.Skype + "?chat" %>' runat="server" Visible="<%# Item.Skype != null %>">
                                <asp:Image ImageUrl="~/Images/social/32/skype.png" runat="server" />
                            </asp:HyperLink>
                            <asp:HyperLink NavigateUrl='<%# "http://www.facebook.com/" + Item.Skype %>' runat="server" Visible="<%# Item.Facebook != null %>" Target="_blank">
                                <asp:Image ImageUrl="~/Images/social/32/facebook.png" runat="server" />
                            </asp:HyperLink>
                        </p>
                    </div>
                    <a class="btn btn-primary" href="User/Settings.aspx"><i class="icon-user icon-edit"></i> Edit Profile</a>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <h4>No such user!</h4>
                </EmptyDataTemplate>
            </asp:FormView>
        </div>
        <div class="span9">
            <userControls:Twitter runat="server" ID="TwitterPanel" />
        </div>
    </div>
</asp:Content>
