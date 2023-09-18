<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="mainpage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="StyleSheet.css" rel="stylesheet" />
    <h2>Listeleme <small>Users</small></h2>
    <p></p>
    <div class="container-header">
        <div class="table">
            <div class="table-header">
                <div class="header__item"><a id="id" class="filter__link" href="#">User ID</a></div>
                <div class="header__item"><a id="l_name" class="filter__link filter__link--number" href="#">Login Name</a></div>
                <div class="header__item"><a id="pass" class="filter__link filter__link--number" href="#">Password</a></div>
                <div class="header__item"><a id="l_name1" class="filter__link filter__link--number" href="#">FIRST Name</a></div>
                <div class="header__item"><a id="l_name2" class="filter__link filter__link--number" href="#">Last Name</a></div>
                <div class="header__item"><a id="auth" class="filter__link filter__link--number" href="#">Authority Level</a></div>
                <div class="header__item"><a id="bday" class="filter__link filter__link--number" href="#">Birthday</a></div>
                <div class="header__item"><a id="salary" class="filter__link filter__link--number" href="#">Salary</a></div>
            </div>
        </div>
    </div>
    <div class="container">
        <asp:DataList ID="DataList2" runat="server" Width="1127px">
            <ItemTemplate>
                <div class="table">
                    <div class="table-content">
                        <div class="table-row">
                            <div class="table-data">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("User_ID") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Login_name") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("First_name") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Last_name") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Authority_Level") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Birthday", "{0:d}") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("Salary") %>'></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div id="Paging" class="page-buttons" runat="server">
        <asp:Button ID="btnFirst" runat="server" Font-Bold="true" Text="First" OnClick="btnFirst_Click" />
        <asp:Button ID="btnPre" runat="server" Font-Bold="true" Text="Previous" OnClick="btnPre_Click" />
        <asp:Button ID="btnNext" runat="server" Font-Bold="true" Text="Next" OnClick="btnNext_Click" />
        <asp:Button ID="btnLast" runat="server" Font-Bold="true" Text="Last" OnClick="btnLast_Click" />
        <asp:Label ID="lblCurrentPage" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>



