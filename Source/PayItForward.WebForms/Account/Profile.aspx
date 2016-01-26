<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PayItForward.WebForms.Account.Profile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="card-panel hoverable  cooldown">
        <h5 class="center blue-grey-text ">Profile</h5>
    </div>
    <div class="row">
        <div class="col s12 m4 l4">
            <div id="profile-card" class="card">
                <div class="card-image waves-effect waves-block waves-light">
                    <img class="activator" src="../Resources/Images/user-bg.jpg" alt="user bg">
                </div>
                <div class="card-content">

                    <img src="<%= CurrentUser!=null?CurrentUser.AvatarUrl:""%>" alt="" class="circle responsive-img activator card-profile-image">
                    <a runat="server" href="~/Account/ManagePassword" class="btn-floating activator btn-move-up waves-effect waves-light darken-2 right">
                        <i class="mdi-editor-mode-edit"></i>
                    </a>

                    <span class="card-title activator grey-text text-darken-4"><%= CurrentUser!=null? CurrentUser.UserName:"" %></span>
                    <p><i class="mdi-action-perm-identity"></i><%= CurrentUser!=null?CurrentUser.Email:"" %></p>

                </div>
            </div>
        </div>
        <div class="col col s12 m8 l8">
            <asp:UpdatePanel runat="server" ID="UpdateGridPanel">
                <ContentTemplate>

                    <asp:GridView ID="GridViewDonations" runat="server"
                        SelectMethod="GridViewDonations_GetData"
                        ItemType="PayItForward.Data.Models.Donation"
                        AllowPaging="True"
                        PageSize="5"
                        AllowSorting="True"
                        DataKeyNames="Id"
                        MultipleActiveResultSets="true"
                        AutoGenerateColumns="false"
                        CssClass="bordered hoverable striped">

                        <Columns>
                            <asp:BoundField DataField="Story.Title" HeaderText="Story" SortExpression="Story.Title" />
                            <asp:BoundField DataField="Ammount" HeaderText="Amount Donated" SortExpression="Ammount" />
                            <asp:BoundField DataField="Story.CollectedAmount" HeaderText="CollectedAmount for the Story" SortExpression="Story.CollectedAmount" />
                            <asp:BoundField DataField="Story.GoalAmount" HeaderText="Goal GoalAmount for the story" SortExpression="Story.GoalAmount" />
                            <asp:BoundField DataField="Story.ExpirationDate" HeaderText="Expiration Date for the story" SortExpression="Story.ExpirationDate" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
