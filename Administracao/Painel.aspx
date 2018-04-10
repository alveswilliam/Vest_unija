<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Painel.aspx.cs" Inherits="Administracao_Painel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link href="../css/estilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                            <li><a id="linkSair" runat="server" href="#"><span class="glyphicon glyphicon-log-out"></span>Sair</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div class="row">
                <div class="col-md-12 col-xs-12">
                    <h2>Controle Administrativo</h2>
                </div>
            </div>
            <div id="divPolo" runat="server" visible="false">
                <div class="row">
                    <div class="col-md-12 col-xs-12">
                        <asp:DropDownList ID="ddlPolo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPolo_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-xs-12">
                    <h3>Informações dos candidatos</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-xs-12">
                    <asp:UpdatePanel ID="upTabelaCandidatos" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvInscritos" runat="server" AutoGenerateColumns="false" CssClass="table table-hover" ShowHeaderWhenEmpty="true" EmptyDataText="Não há candidatos inscritos">
                                <Columns>
                                    <asp:BoundField DataField="CODIGOINSCRICAO" HeaderText="Cód. Inscrição" SortExpression="CODIGOINSCRICAO" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="NOME" HeaderText="Candidato" SortExpression="NOME" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="TELEFONE1" HeaderText="Telefone" SortExpression="TELEFONE1" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="TELEFONE2" HeaderText="Celular" SortExpression="TELEFONE2" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="CPF" HeaderText="CPF" SortExpression="CPF" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="CIDADE" HeaderText="Cidade" SortExpression="CIDADE" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="EMAIL" HeaderText="E-mail" SortExpression="EMAIL" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="POLO" HeaderText="Polo" SortExpression="POLO" ItemStyle-HorizontalAlign="Center" />
                                </Columns>
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
        </form>
    </div>
</body>
<script type="text/javascript" src="http://code.jquery.com/jquery-2.2.1.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</html>
