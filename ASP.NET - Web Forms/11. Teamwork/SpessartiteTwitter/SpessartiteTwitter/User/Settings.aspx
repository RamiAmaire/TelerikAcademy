<%@ Page Title="User Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="SpessartiteTwitter.Registered.Settings" %>

<asp:Content ID="ContentSettings" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="FormViewSettings" ItemType="SpessartiteTwitter.Data.AspNetUser"
        SelectMethod="FormViewSettings_GetItem" DefaultMode="Edit" DataKeyNames="Id"
        UpdateMethod="FormViewSettings_UpdateItem">
        <EditItemTemplate>
            <ol>
                <asp:DynamicEntity runat="server" Mode="Edit"></asp:DynamicEntity>
                <asp:CheckBoxList ID="CheckBoxListRoles" runat="server"
                    ItemType="SpessartiteTwitter.Data.AspNetRole"
                    SelectMethod="CheckBoxListRoles_GetAll"
                    DataTextField="Name"
                    DataValueField="Id" OnDataBound="CheckBoxListRoles_DataBound" />
                <span>Upload Profile Picture
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
