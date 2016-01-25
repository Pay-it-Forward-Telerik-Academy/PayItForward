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
                UpdateMethod="GridViewStories_UpdateData"
                ItemType="PayItForward.Data.Models.Story"
                AllowPaging="True"
                PageSize="5"
                AllowSorting="True"
                DataKeyNames="Id"
                AutoGenerateEditButton="true"
                AutoGenerateColumns="false"
                CssClass="bordered hoverable striped">

                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" ReadOnly="true" />
                    <asp:BoundField DataField="ExpirationDate" HeaderText="ExpirationDate" SortExpression="ExpirationDate" ReadOnly="true" />
                    <asp:BoundField DataField="Category.Name" HeaderText="Category" SortExpression="Category.Name" ReadOnly="true" />
                    <asp:TemplateField HeaderText="IsAccept">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkStatus" Checked="<%# BindItem.IsAccept %>" Text="Accept" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
