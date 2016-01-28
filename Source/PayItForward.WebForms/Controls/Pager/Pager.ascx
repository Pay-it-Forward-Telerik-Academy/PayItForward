<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="PayItForward.WebForms.Controls.Pager.Pager" %>
<div style="font-size: 8pt; font-family: Verdana;">
    <div id="left" style="float: left;">
        <span>Page</span>
        <asp:DropDownList ID="ddlPageNumber" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageNumber_SelectedIndexChanged"></asp:DropDownList>
        <%--<span>of</span>--%>
        <asp:Label Visible="false" ID="lblShowRecords" runat="server"></asp:Label>
        <%--<span>Pages</span>--%>
    </div>
    <div id="right" style="float: right;">
        <span>Display</span>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="5" Value="5" Selected="true"></asp:ListItem>
            <asp:ListItem Text="10" Value="10"></asp:ListItem>
            <asp:ListItem Text="20" Value="20"></asp:ListItem>
            <asp:ListItem Text="25" Value="25"></asp:ListItem>
            <asp:ListItem Text="50" Value="50"></asp:ListItem>
        </asp:DropDownList>
        <span>Records per Page</span>
    </div>
</div>
