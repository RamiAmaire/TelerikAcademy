<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="SpessartiteTwitter.Admin.EditUser" %>

<asp:Content ID="ContentEditUser" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="FormViewEditUser" ItemType="SpessartiteTwitter.Data.AspNetUser"
         DefaultMode="Edit" DataKeyNames="Id"
        >
        <EditItemTemplate>
            <ol>
                <asp:DynamicEntity runat="server" Mode="Edit"></asp:DynamicEntity>
                <span>
                    Upload Profile Picture
                    <asp:FileUpload runat="server" ID="ProfilePictureFileUpload" />
                </span>
                <br />
                <br />
                <asp:LinkButton ID="ButtonSaveChanges" CommandName="Update"
                Text="Save changes" runat="server" />
            </ol>
        </EditItemTemplate>
    </asp:FormView>

</asp:Content>
