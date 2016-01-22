<%@ Page Title="Create new story" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreateStory.aspx.cs" Inherits="PayItForward.WebForms.Story.CreateStory" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal col-md-8">
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Title" CssClass="col-md-3 control-label">Story's title</asp:Label>
            <div class="col-md-9">
                <asp:TextBox runat="server" ID="Title" Placeholder="Enter a story's title (required)" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Title"
                    CssClass="text-danger" ErrorMessage="Please enter a story's title!" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DropDownListCategories" CssClass="col-md-3 control-label">Category</asp:Label>
            <div class="col-md-9">
                <asp:DropDownList ID="DropDownListCategories" runat="server" CssClass="form-control" OnSelectedIndexChanged="OnDropDownListCategoriesSelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Image" CssClass="col-md-3 control-label">Cover</asp:Label>
            <div class="col-md-9">
                <asp:FileUpload ID="Image" runat="server" CssClass="form-control" accept="image/*" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Image"
                    CssClass="text-danger" ErrorMessage="Please upload an story's cover image!" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="GoalAmount" CssClass="col-md-3 control-label">GoalAmount</asp:Label>
            <div class="col-md-9">
                <asp:TextBox runat="server" ID="Price" CssClass="form-control" Placeholder="Enter a goal amount(required)" TextMode="Number" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="GoalAmount"
                    CssClass="text-danger" ErrorMessage="Please specify goal amount of the story!" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-3 control-label">Description</asp:Label>
            <div class="col-md-9">
                <asp:TextBox runat="server" ID="Description" CssClass="form-control" Placeholder="Enter a story's description (optional)" TextMode="MultiLine" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Year" CssClass="col-md-3 control-label">Year of release</asp:Label>
            <div class="col-md-9">
                <asp:TextBox runat="server" ID="Year" CssClass="form-control" Placeholder="Enter a book's release year (optional)" TextMode="Number" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-3 col-md-9">
                <asp:Button runat="server" OnClick="OnCreateBookButtonClicked" Text="Create Book" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
