<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Final.aspx.cs" Inherits="Final" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Vestibular UniJÁ - Inscrição realizada</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link href="css/estilo.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
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
            <div class="row">
                <div class="col-md-12 col-xs-12 text-center">
                    <h2>Inscrição realizada com sucesso.</h2>
                </div>
                <div class="col-md-12 col-xs-12">
                    <div class="alert alert-info text-center" role="banner">
                        <span class="glyphicon glyphicon-info-sign"></span><span id="spanInstrucoes" runat="server"></span>
                        <a id="linkNova" runat="server" href="#" class="alert-link">Nova inscrição</a>
                    </div>
                    <p>
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-xs-12 text-center">
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
		</div>
    </form>
</body>
<script lang="javascript" type="text/javascript" src="js/jquery-2.1.4.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>
