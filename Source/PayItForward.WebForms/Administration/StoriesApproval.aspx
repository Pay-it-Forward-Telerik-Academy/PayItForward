<%@ Page Title="" Language="C#"
    MasterPageFile="~/Administration/Administration.master"
    AutoEventWireup="true"
    CodeBehind="StoriesApproval.aspx.cs"
    Inherits="PayItForward.WebForms.Administration.StoriesApproval" %>

<asp:Content ID="StoriesApproval" ContentPlaceHolderID="AdminContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdateGridPanel">
        <ContentTemplate>

            <asp:GridView ID="GridViewStories" runat="server"
                SelectMethod="GridViewStories_GetData"
                UpdateMethod="GridViewStories_UpdateItem"
                ItemType="PayItForward.Data.Models.Story"
                AllowPaging="True"
                PageSize="5"
                AllowSorting="True"
                DataKeyNames="Id"
                AutoGenerateEditButton="true"
                AutoGenerateColumns="false"
                CssClass="bordered hoverable striped">

                <EmptyDataTemplate>
                    <div class="card-panel">
                        <h2>There are no books to approval!</h2>
                    </div>
                </EmptyDataTemplate>

                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" ReadOnly="true" />
                    <asp:BoundField DataField="ExpirationDate" HeaderText="ExpirationDate" SortExpression="ExpirationDate" ReadOnly="true" />
                    <asp:BoundField DataField="Category.Name" HeaderText="Category" SortExpression="Category.Name" ReadOnly="true" />
                    <asp:BoundField DataField="IsAccept" HeaderText="IsAccept" SortExpression="IsAccept" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
