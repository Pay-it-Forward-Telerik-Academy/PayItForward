<%@ Page Title="Create new story" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Create.aspx.cs" Inherits="PayItForward.WebForms.Story.CreateStory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="row">
        <div class="input-field col s12">
            <asp:TextBox runat="server" ID="TitleStory" TextMode="SingleLine" CssClass="form-control" />
            <label for="email">Title</label>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="TitleStory"
                CssClass="text-danger" ErrorMessage="The password field is required." />
        </div>
    </div>

    <asp:Label runat="server" AssociatedControlID="DropDownListCategories" CssClass="col-md-3 control-label">Category</asp:Label>
    <asp:DropDownList ID="DropDownListCategories" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control"></asp:DropDownList>


    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Image" CssClass="col-md-3 control-label">Cover</asp:Label>
        <div class="col-md-9">
            <asp:FileUpload ID="Image" runat="server" CssClass="form-control" accept="image/*" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Image"
                CssClass="text-danger" ErrorMessage="Please upload an story's cover image!" />
        </div>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="Document" CssClass="col-md-3 control-label">Document</asp:Label>
        <div class="col-md-9">
            <asp:FileUpload ID="Document" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Document"
                CssClass="text-danger" ErrorMessage="Please upload document that confirm your story!" />
        </div>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="GoalAmount" CssClass="col-md-3 control-label">GoalAmount</asp:Label>
        <div class="col-md-9">
            <asp:TextBox runat="server" ID="GoalAmount" CssClass="form-control" Placeholder="Enter a goal amount(required)" TextMode="Number" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="GoalAmount"
                CssClass="text-danger" ErrorMessage="Please specify goal amount of the story!" />
        </div>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="EstimatedDays" CssClass="col-md-3 control-label">EstimatedDays</asp:Label>
        <div class="col-md-9">
            <asp:TextBox runat="server" ID="EstimatedDays" CssClass="form-control" Placeholder="Enter a EstimatedDays" TextMode="Number" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="EstimatedDays"
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
        <div class="col-md-offset-3 col-md-9">
            <asp:Button runat="server" OnClick="OnCreateStoryButtonClicked" Text="Create Story" CssClass="btn btn-default" />
        </div>
    </div>
     <script>
        $(document).ready(function () {
            $('select').material_select();
        });
    </script>
</asp:Content>

