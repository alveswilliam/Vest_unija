<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inscricao.aspx.cs" Inherits="Inscricao" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Vestibular UniJÁ - Inscrição</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link href="css/estilo.css" rel="stylesheet" type="text/css" />
    <link href="css/radio_check_css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/radio_check_css/build.css" rel="stylesheet" type="text/css" />

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
            <div class="row espacamento">
                <div class="col-md-12 col-xs-12 text-center">
                    <h1>Vestibular UniJÁ</h1>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12 col-xs-12 text-left">
                    <h3><span class="titulo">Formulário de Inscrição</span></h3>
                </div>
            </div>

            <div id="divDadosPessoais" class="bloco">

                <%-- PÁGINA 1 --%>
                <div id="divPagina1" runat="server">
                    <div class="row">
                        <div class="col-md-12 col-xs-12 text-left">
                            <h3><span class="glyphicon glyphicon-user"></span>Dados pessoais</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-12">
                            Nome completo
                        </div>
                        <div class="col-md-8 col-xs-12">
                            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" MaxLength="120"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-12">
                            Cidade/Estado de sua residência
                        </div>
                        <div class="col-md-7 col-xs-7">
                            <asp:TextBox ID="txtCidade" runat="server" CssClass="form-control" MaxLength="120"></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-xs-5">
                            <asp:TextBox ID="txtUF" runat="server" CssClass="form-control" MaxLength="2"></asp:TextBox>
                        </div>
                    </div>
                    <%--<div class="row">
                        <div class="col-md-4 col-xs-12">
                            CPF
                        </div>
                        <div class="col-md-3 col-xs-12">
                            <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" MaxLength="14"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-xs-12">
                            Data de nascimento
                        </div>
                        <div class="col-md-3 col-xs-12">
                            <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                        </div>
                    </div>--%>

                    <div class="row">
                        <div class="col-md-4 col-xs-12">
                            CPF/Data de nascimento
                        </div>
                        <div class="col-md-4 col-xs-4">
                            <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" MaxLength="14"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-xs-8">
                            <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                        </div>
                    </div>

                    <%--<div class="row">
                        <div class="col-md-4 col-xs-12">
                            E-mail
                        </div>
                        <div class="col-md-3 col-xs-12">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                        </div>
                        <div class="col-md-2 col-xs-12">
                            Celular/Telefone<span class="instrucoes"> (preferencialmente celular)</span>
                        </div>
                        <div class="col-md-3 col-xs-12">
                            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                        </div>
                    </div>--%>

                    <div class="row">
                        <div class="col-md-4 col-xs-12">
                            E-mail/Celular/Telefone<span class="instrucoes"> (preferencialmente celular)</span>
                        </div>
                        <div class="col-md-4 col-xs-6">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-xs-6">
                            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-8">
                            Sexo
                        </div>
                        <div class="col-md-8 col-xs-12">
                            <asp:RadioButtonList ID="rblSexo" runat="server" CssClass="radio radio-primary">
                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                                <asp:ListItem Value="F">Feminino</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-xs-12 text-left">
                            <h3><span class="glyphicon glyphicon-user"></span>Informações do polo</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-xs-12">
                            Polo
                        <asp:DropDownList ID="ddlPolo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPolo_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 col-xs-12 text-left">
                            Cursos
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-xs-12">
                            <asp:DropDownList ID="ddlCurso" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 col-xs-12 text-left">
                            Forma de ingresso
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-xs-12">
                            <asp:DropDownList ID="ddlFormaIngresso" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                <asp:ListItem Value="Vestibular">Vestibular</asp:ListItem>
                                <asp:ListItem Value="Enem">ENEM</asp:ListItem>
                                <asp:ListItem Value="Encceja">ENCCEJA</asp:ListItem>
                                <asp:ListItem Value="Segunda graduação">Segunda graduação</asp:ListItem>
                                <asp:ListItem Value="Transferência">Transferência</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row text-center">
                        <div class="col-md-12 col-xs-12">
                            <asp:Button ID="btnAvancar1" runat="server" Text="Avançar" CssClass="btn btn-primary" OnClick="btnAvancar1_Click" />
                        </div>
                    </div>
                </div>

                <%-- PÁGINA 2 --%>
                <div id="divPagina2" runat="server" visible="false">
                    <asp:UpdatePanel ID="upCEP" runat="server">
                        <ContentTemplate>
                            <div id="divCepInvalido" style="display: none; right: 50px; top: 1230px; background-color: #fff; overflow: auto; z-index: 2; border: 1px solid #d9d9d9; border-radius: 10px; box-shadow: 12px 12px 5px #888888; padding: 10px;">
                                Não encontramos o CEP informado. Por favor, acesse o site dos Correios (<a href="http://www.buscacep.correios.com.br/servicos/dnec/menuAction.do?Metodo=menuEndereco">Site dos correios</a>) 
                    e faça a pesquisa pelo nome da rua. Se necessário, contate a comissão do 
                    vestibular pelo email comvest@poliseducacional.com.br
                            </div>
                            <div id="divEndereco">
                                <div class="row">
                                    <div class="col-md-12 col-xs-12 text-left">
                                        <h3><span class="glyphicon glyphicon-home"></span>Endereço</h3>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2 col-xs-12">
                                        <a id="linkCepInvalido" runat="server" visible="false" onclick="JavaScript:habilitaCampoCepInvalido('divCepInvalido');">
                                            <img id="img" src="img/cep_invalido.png" alt="CEP não encontrado" />
                                            CEP não encontrado
                                        </a>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 col-xs-12">
                                        CEP <span class="instrucoes">(Somente números)</span>
                                    </div>
                                    <div class="col-md-6 col-xs-12">
                                        <asp:TextBox ID="txtCEP" runat="server" CssClass="form-control" MaxLength="8" AutoPostBack="true" OnTextChanged="txtCEP_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 col-xs-12">
                                        Endereço/Número
                                    </div>
                                    <div class="col-md-7 col-xs-7">
                                        <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1 col-xs-5">
                                        <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 col-xs-12">
                                        Bairro/Complemento
                                    </div>
                                    <div class="col-md-4 col-xs-7">
                                        <asp:TextBox ID="txtComplemento" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-xs-5">
                                        <asp:TextBox ID="txtBairro" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                </div>
                                <div class="row">
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="row">
                        <div class="col-md-4 col-xs-12">
                            Ensino Médio
                        </div>
                        <div class="col-md-3 col-xs-12">
                            <asp:DropDownList ID="ddlEscolaridade" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                <asp:ListItem Value="6">Incompleto</asp:ListItem>
                                <asp:ListItem Value="7">Completo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <%--<div class="row text-center">
                        <div class="col-md-12 col-xs-12">
                            <asp:Button ID="btnAvancar2" runat="server" Text="Avançar" CssClass="btn btn-primary" OnClick="btnAvancar2_Click" />
                        </div>
                    </div>--%>

                    <div class="blocoDeclaracao">
                        <div class="row">
                            <div class="col-md-12 col-xs-12">
                                <p class="declaracao">
                                    <span class="glyphicon glyphicon-check" aria-hidden="true"></span>Declaro a veracidade das informações prestadas e de estar ciente das normas do Vestibular  
                        <asp:Label ID="lblAnoVestibular" runat="server"></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-xs-12 text-center">
                            <asp:Button ID="btnInscrever" runat="server" Text="Efetuar inscrição" CssClass="btn btn-primary" OnClick="btnInscrever_Click"></asp:Button>
                        </div>
                    </div>

                </div>

                <%-- PÁGINA 3 --%>
                <%--<div id="divPagina3" runat="server" visible="false">


                    <div class="row text-center">
                        <div class="col-md-12 col-xs-12">
                            <asp:Button ID="btnAvancar3" runat="server" Text="Avançar" CssClass="btn btn-primary" OnClick="btnAvancar3_Click" />
                        </div>
                    </div>
                </div>--%>

                <%-- PÁGINA 4 --%>
                <%--<div id="divPagina4" runat="server" visible="false">
                    <div class="row">
                        <div class="col-md-12 col-xs-12 text-left">
                            <h3><span class="glyphicon glyphicon-user"></span>Informações adicionais</h3>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-1 col-xs-12">
                            Cor/Raça
                        </div>
                        <div class="col-md-2 col-xs-12">
                            <asp:DropDownList ID="ddlCorRaca" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                <asp:ListItem Value="Branca">Branca</asp:ListItem>
                                <asp:ListItem Value="Preta">Preta</asp:ListItem>
                                <asp:ListItem Value="Amarela">Amarela</asp:ListItem>
                                <asp:ListItem Value="Parda">Parda</asp:ListItem>
                                <asp:ListItem Value="Indígena">Indígena</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 col-xs-12">
                            Estado civil
                        </div>
                        <div class="col-md-3 col-xs-12">
                            <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                <asp:ListItem Value="C">Casado</asp:ListItem>
                                <asp:ListItem Value="D">Desquitado</asp:ListItem>
                                <asp:ListItem Value="I">Divorciado</asp:ListItem>
                                <asp:ListItem Value="M">Marital</asp:ListItem>
                                <asp:ListItem Value="S">Solteiro</asp:ListItem>
                                <asp:ListItem Value="V">Viúvo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 col-xs-8">
                            Nacionalidade
                        </div>
                        <div class="col-md-2 col-xs-12">
                            <asp:DropDownList ID="ddlNacionalidade" runat="server" CssClass="form-control">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                                <asp:ListItem Value="10">Brasileira</asp:ListItem>
                                <asp:ListItem Value="50">Outra</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div> 
                    <div class="row">
                        <div class="col-md-2 col-xs-8">
                            Canhoto
                        </div>
                        <div class="col-md-10 col-xs-12">
                            <asp:RadioButtonList ID="rblCanhoto" runat="server" CssClass="radio radio-primary">
                                <asp:ListItem Value="1">Sim</asp:ListItem>
                                <asp:ListItem Value="0">Não</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 col-xs-12 text-left">
                            <h3>Necessidade especial</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-xs-12">
                            Portador de necessidade especial?
                        </div>
                        <div class="col-md-8 col-xs-12">
                            <asp:RadioButtonList ID="rblPortador" runat="server" CssClass="radio radio-primary">
                                <asp:ListItem Value="S">Sim</asp:ListItem>
                                <asp:ListItem Value="N" Selected="True">Não</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div id="divNecessidadeEspecial" runat="server">
                        <div class="row">
                            <div class="col-md-4 col-xs-12">
                                Qual?
                            </div>
                            <div class="col-md-8 col-xs-12">
                                <asp:CheckBoxList ID="cblNecessidade" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">Auditiva</asp:ListItem>
                                    <asp:ListItem Value="2">Física</asp:ListItem>
                                    <asp:ListItem Value="3">Visual</asp:ListItem>
                                    <asp:ListItem Value="4">Mental</asp:ListItem>
                                    <asp:ListItem Value="5">Outros</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-xs-12">
                                Especifique a necessidade especial
                            </div>
                            <div class="col-md-8 col-xs-12">
                                <asp:TextBox ID="txtEspecificacao" runat="server" TextMode="MultiLine" Columns="40" Rows="3" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-xs-12">
                                Indique a necessidade de recursos adicionais para realização da prova
                            </div>
                            <div class="col-md-8 col-xs-12">
                                <asp:TextBox ID="txtRecursos" runat="server" TextMode="MultiLine" Columns="40" Rows="3" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row text-center">
                        <div class="col-md-12 col-xs-12">
                            <asp:Button ID="btnAvancar4" runat="server" Text="Avançar" CssClass="btn btn-primary" OnClick="btnAvancar4_Click" />
                        </div>
                    </div>
                </div>--%>

                <%-- PÁGINA 5 --%>
                <%--<div id="divPagina5" runat="server" visible="false">
                    <asp:UpdatePanel ID="upEscolaridade" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-12 col-xs-12 text-left">
                                    <h3><span class="glyphicon glyphicon-book"></span>Escolaridade</h3>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-xs-12">
                                    Ensino Médio
                                </div>
                                <div class="col-md-3 col-xs-12">
                                    <asp:DropDownList ID="ddlEscolaridade" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlEscolaridade_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="">Selecione</asp:ListItem>
                                        <asp:ListItem Value="6">Incompleto</asp:ListItem>
                                        <asp:ListItem Value="7">Completo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3 col-xs-12">
                                    <asp:Label ID="lblAnoConclusao" runat="server" Text="Conclusão"></asp:Label>
                                </div>
                                <div class="col-md-3 col-xs-12">
                                    <asp:DropDownList ID="ddlAnoConclusao" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-xs-12">
                                    Formação
                                </div>
                                <div class="col-md-3 col-xs-12">
                                    <asp:DropDownList ID="ddlFormacao" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">Selecione</asp:ListItem>
                                        <asp:ListItem Value="Integralmente em escola pública">Integralmente em escola pública</asp:ListItem>
                                        <asp:ListItem Value="Maior parte em escola pública">Maior parte em escola pública</asp:ListItem>
                                        <asp:ListItem Value="Integralmente em escola particular">Integralmente em escola particular</asp:ListItem>
                                        <asp:ListItem Value="Maior parte em escola particular">Maior parte em escola particular</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3 col-xs-12">
                                    Escola
                                </div>
                                <div class="col-md-3 col-xs-12">
                                    <asp:TextBox ID="txtEscola" runat="server" CssClass="form-control" MaxLength="60"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 col-xs-12">
                                    Ensino Superior
                                </div>
                                <div class="col-md-9 col-xs-12">
                                    <asp:DropDownList ID="ddlEnsinoSuperior" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">Selecione</asp:ListItem>
                                        <asp:ListItem Value="Completo">Completo</asp:ListItem>
                                        <asp:ListItem Value="Incompleto">Incompleto</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="row text-center">
                        <div class="col-md-12 col-xs-12">
                            <asp:Button ID="btnAvancar5" runat="server" Text="Avançar" CssClass="btn btn-primary" OnClick="btnAvancar5_Click" />
                        </div>
                    </div>
                </div>--%>


                <%--<div id="divPagina6" runat="server" visible="false">
                    <div class="row">
                        <div class="col-md-12 col-xs-12">
                            <h3><span class="glyphicon glyphicon-time"></span>Indique seus dias e períodos disponíveis</h3>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th><strong>Segunda-feira</strong></th>
                                    <th><strong>Terça-Feira</strong></th>
                                    <th><strong>Quarta-Feira</strong></th>
                                    <th><strong>Quinta-Feira</strong></th>
                                    <th><strong>Sexta-Feira</strong></th>
                                    <th><strong>Sábado</strong></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="cbSegunda" runat="server">
                                            <asp:ListItem>Manhã</asp:ListItem>
                                            <asp:ListItem>Tarde</asp:ListItem>
                                            <asp:ListItem>Noite</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                    <td>
                                        <asp:CheckBoxList ID="cbTerca" runat="server">
                                            <asp:ListItem>Manhã</asp:ListItem>
                                            <asp:ListItem>Tarde</asp:ListItem>
                                            <asp:ListItem>Noite</asp:ListItem>
                                        </asp:CheckBoxList></td>
                                    <td>
                                        <asp:CheckBoxList ID="cbQuarta" runat="server">
                                            <asp:ListItem>Manhã</asp:ListItem>
                                            <asp:ListItem>Tarde</asp:ListItem>
                                            <asp:ListItem>Noite</asp:ListItem>
                                        </asp:CheckBoxList></td>
                                    <td>
                                        <asp:CheckBoxList ID="cbSexta" runat="server">
                                            <asp:ListItem>Manhã</asp:ListItem>
                                            <asp:ListItem>Tarde</asp:ListItem>
                                            <asp:ListItem>Noite</asp:ListItem>
                                        </asp:CheckBoxList></td>
                                    <td>
                                        <asp:CheckBoxList ID="cbQuinta" runat="server">
                                            <asp:ListItem>Manhã</asp:ListItem>
                                            <asp:ListItem>Tarde</asp:ListItem>
                                            <asp:ListItem>Noite</asp:ListItem>
                                        </asp:CheckBoxList></td>
                                    <td>
                                        <asp:CheckBoxList ID="cbSabado" runat="server">
                                            <asp:ListItem>Manhã</asp:ListItem>
                                            <asp:ListItem>Tarde</asp:ListItem>
                                        </asp:CheckBoxList></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>--%>
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
<script type="text/javascript" src="http://code.jquery.com/jquery-2.2.1.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/masks.js" charset="iso-8859-1"></script>
<script type="text/javascript" src="js/habilitaCampos.js"></script>
</html>
