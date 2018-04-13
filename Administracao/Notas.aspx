<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notas.aspx.cs" Inherits="Administracao_Notas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vestibular UniJÁ 2018 - Lançamento de Notas</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link href="../css/estilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="page-header">
                <div id="topoBanner" class="row">
                    <div class="col-md-12 col-xs-12" id="divEspacoBanner">
                        <div id="divBanner" runat="server"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-xs-12">
                    </div>
                </div>
            </div>
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="#"><span class="glyphicon glyphicon-user"></span><span id="spanUsuario" runat="server"></span></a></li>
                            <li><a href="Painel.aspx"><span class="glyphicon glyphicon-home"></span>Menu principal</a></li>
                            <li><a href="Login.aspx"><span class="glyphicon glyphicon-log-out"></span>Sair</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div class="row">
                <div class="col-md-12 col-xs-12">
                    <h2>Controle Administrativo</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-xs-12">
                    <h3>Lançamento de notas - <span id="spanPolo" runat="server"></span></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-xs-12">
                    <asp:UpdatePanel ID="upCandidatos" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvNotaCandidatos" runat="server" AutoGenerateColumns="false" CssClass="table table table-hover" ShowHeaderWhenEmpty="true" EmptyDataText="Não há candidatos para lançamento de nota" OnRowUpdating="gvNotaCandidatos_RowUpdating" OnRowEditing="gvNotaCandidatos_RowEditing" OnRowCancelingEdit="gvNotaCandidatos_RowCancelingEdit">
                                <Columns>
                                    <asp:BoundField DataField="CODIGOINSCRICAO" HeaderText="Inscrição" SortExpression="CODIGOINSCRICAO" ReadOnly="True"></asp:BoundField>
                                    <asp:BoundField DataField="NOME" HeaderText="Nome" SortExpression="NOME" ReadOnly="True"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Nota" SortExpression="NOTA">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtNota" runat="server" Text='<%#Bind("NOTATOTAL") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNota" runat="server" Text='<%#Bind("NOTATOTAL") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Button" ShowEditButton="true" UpdateText="Lançar" CancelText="Cancelar" EditText="Editar" ControlStyle-CssClass="btn btn-primary" />
                                </Columns>
                                <HeaderStyle BackColor="#0a385a" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-xs-12">
                    <div class="alert alert-danger" role="alert" runat="server" id="divMsg" visible="false">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <strong>Atenção! </strong><span id="spanMsg" runat="server"></span>
                    </div>
                </div>
            </div>
            <br />
        </div>
    </form>
</body>
<script type="text/javascript" src="http://code.jquery.com/jquery-2.2.1.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</html>
