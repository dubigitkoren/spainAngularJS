<!doctype html>
<html ng-app="app">
<head>
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/ui-grid.min.js"></script>
    <script src="Scripts/angular-route.js"></script>
    <link href="Content/ui-grid.min.css" rel="stylesheet" />
    <script src="Scripts/app.js"></script>
</head>
<body style="background: linear-gradient(to right, #e3eaa7, #d5e1df);">
    <br />
    <h1 style="color:coral;text-align:center">List of Records</h1>
    <br />
    <div ng-controller="MainCtrl as $ctrl">
        <div id="grid1" ui-grid="gridOptions" class="grid"></div>
    </div>
    <br />
    <button id="Button1" data-toggle="modal" data-target="#enterRowModal">Insert New Row</button>
    <a href="insert">insert</a>


</body>
</html>

<%--<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  
    <span class="glyphicon glyphicon-search" aria-hidden="true"></span>

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="Grid" AlternatingRowStyle-CssClass="alt" DataSourceID="SqlDataSource2" EmptyDataText="There are no data records to display.">
        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Record ID" ReadOnly="True" SortExpression="ID"  />
            <asp:BoundField DataField="CreateDate" HeaderText="Create Date" SortExpression="CreateDate" />
            <asp:BoundField DataField="DateOfAuto" HeaderText="Date Of Auto" SortExpression="DateOfAuto" />
            <asp:BoundField DataField="Tribunal" HeaderText="Tribunal" SortExpression="Tribunal" />
            <asp:BoundField DataField="TypeOfAuto" HeaderText="Type Of Auto" SortExpression="TypeOfAuto" />
            <asp:BoundField DataField="LocationOfAuto" HeaderText="Location Of Auto" SortExpression="LocationOfAuto" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Aliases" HeaderText="Aliases" SortExpression="Aliases" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" SortExpression="DateOfBirth" />
            <asp:BoundField DataField="PersonalStatus" HeaderText="Personal Status" SortExpression="PersonalStatus" />
            <asp:BoundField DataField="Occupation" HeaderText="Occupation" SortExpression="Occupation" />
            <asp:BoundField DataField="FamilyTies" HeaderText="Family Ties" SortExpression="FamilyTies" />
            <asp:BoundField DataField="LocationOfBirth" HeaderText="Location Of Birth" SortExpression="LocationOfBirth" />
            <asp:BoundField DataField="Residence" HeaderText="Residence" SortExpression="Residence" />
            <asp:BoundField DataField="TypeOfCrime" HeaderText="Type Of Crime" SortExpression="TypeOfCrime" />
            <asp:BoundField DataField="Sentence" HeaderText="Sentence" SortExpression="Sentence" />
            <asp:BoundField DataField="AdditionalInformation" HeaderText="Additional Information" SortExpression="AdditionalInformation" />
            
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [ID], [CreateDate], [DateOfAuto], [Tribunal], [TypeOfAuto], [LocationOfAuto], [Name], [Aliases], [Gender], [DateOfBirth], [PersonalStatus], [Occupation], [FamilyTies], [LocationOfBirth], [Residence], [TypeOfCrime], [Sentence], [AdditionalInformation] FROM [details]"></asp:SqlDataSource>

    <br />
    <button id="Button1" data-toggle="modal" data-target="#enterRowModal">Insert New Row</button>
    <asp:Button ID="Button2" runat="server" Text="insert row" OnClick="Button2_Click" Enabled="false" Visible="false"/>
    <asp:Button ID="Button3" runat="server" Text="retrieve row" OnClick="Button3_Click" Visible="false"/>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [details]"></asp:SqlDataSource>

    <asp:Label ID="lbl1" runat="server" />
    <div id="enterRowModal" class="modal fade" role="dialog">
        <div class="modal-dialog" style="width:70%;">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Insert New Record</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <label for="example-text-input" class="col-2 col-form-label">Date of Auto de Fé</label>
                        <div class="col-10">
                            <asp:Calendar ID="Calendar1" runat="server" ></asp:Calendar>
                            <%--<input class="form-control" type="date" value="1700-08-19" id="Date-of-Auto" style="width:155px">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-search-input" class="col-2 col-form-label">Tribunal</label>
                        <div class="col-10">                            
                            <asp:TextBox ID="txtTribunal" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-email-input" class="col-2 col-form-label">Type of Auto</label>
                        <div class="col-10">
                             <select class="form-control" id="selTypeofAuto">
                                <option>Publico</option>
                                <option>Particular</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-url-input" class="col-2 col-form-label">Location of Auto</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtLocationofAuto" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-tel-input" class="col-2 col-form-label">Name</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>                            
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-password-input" class="col-2 col-form-label">Aliases</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtAliases" class="form-control" runat="server"></asp:TextBox>                            
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-number-input" class="col-2 col-form-label">Gender</label>
                        <div class="col-10">
                             <select class="form-control" id="selGender">
                                <option>Male</option>
                                <option>Female</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-datetime-local-input" class="col-2 col-form-label">Date of Birth</label>
                        <div class="col-10">
                            <input class="form-control" type="date" value="1700-08-19" id="DateOfBirth" style="width:155px">
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-date-input" class="col-2 col-form-label">Personal Status</label>
                        <div class="col-10">
                             <select class="form-control" id="selPersonalStatus">
                                <option>Married</option>
                                <option>Single</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-month-input" class="col-2 col-form-label">Occupation</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtOccupation" class="form-control" runat="server"></asp:TextBox>                            
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-week-input" class="col-2 col-form-label">Family ties</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtFamilyTies" class="form-control" runat="server"></asp:TextBox>                            
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-time-input" class="col-2 col-form-label">Location of Birth</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtLocationOfBirth" class="form-control" runat="server"></asp:TextBox>                            
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="example-color-input" class="col-2 col-form-label">Residence</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtResidence" class="form-control" runat="server"></asp:TextBox>                            
                        </div>
                    </div>
                     <div class="form-group row">
                        <label for="example-color-input" class="col-2 col-form-label">Type of Crime</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtTypeOfCrime" class="form-control" runat="server"></asp:TextBox>                            
                        </div>
                    </div>
                     <div class="form-group row">
                        <label for="example-color-input" class="col-2 col-form-label">Sentence</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtSentence" class="form-control" runat="server"></asp:TextBox>                            
                        </div>
                    </div>
                     <div class="form-group row">
                        <label for="example-color-input" class="col-2 col-form-label">Additional Information</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtAdditionalInformation" class="form-control" runat="server"></asp:TextBox>                            
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button ID="Button4" runat="server" Text="insert row" OnClick="Button4_Click" class="btn btn-primary"/>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
--%>
