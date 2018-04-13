<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Administracao_Login" %>

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
            <div class="page-header">
                <div id="topoBanner" class="row">
                    <div class="col-md-12 col-xs-12" id="divEspacoBanner">
                        <div id="divBanner" runat="server"></div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-md-12 text-center">
                        <h2>Vestibular UniJÁ - Controle Administrativo</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-xs-12 col-md-4">
                    <h4>Usuário</h4>
                </div>
                <div class="col-md-4"></div>
            </div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-xs-12 col-md-4">
                    <input type="text" class="form-control" id="txtUsuario" runat="server" />
                </div>
                <div class="col-md-4"></div>
            </div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-xs-12 col-md-4">
                    <h4>Senha</h4>
                </div>
                <div class="col-md-4"></div>
            </div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-xs-12 col-md-4">
                    <input type="password" class="form-control" id="txtSenha" runat="server" />
                </div>
                <div class="col-md-4 col-xs-12">
                    <asp:Button ID="btnAcessar" runat="server" Text="Acessar" CssClass="btn btn-primary" OnClick="btnAcessar_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4"></div>
                <div class="col-xs-12 col-md-4">
                    <%--<asp:LinkButton ID="lbtnEsqueceu" runat="server" CssClass="esqueceu" OnClick="lbtnEsqueceu_Click">Esqueceu sua senha? Clique aqui</asp:LinkButton>--%>
                </div>
            </div>
            <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="divMsg" visible="false">
                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                <strong>Atenção! </strong><span id="spanMsg" runat="server"></span>
            </div>
            <br />
        </form>
    </div>
</body>
<script type="text/javascript" src="http://code.jquery.com/jquery-2.2.1.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</html>
