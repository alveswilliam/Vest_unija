function calcular_idade(dataNascimento, evt) {
    dataNascimento = dataNascimento.value.split('/');

    var dia = dataNascimento[0];
    var mes = dataNascimento[1];
    var ano = dataNascimento[2];

    var hoje = new Date();
    var idade = hoje.getFullYear() - ano;
    if (hoje.getMonth() + 1 < mes || (hoje.getMonth() + 1 == mes && hoje.getDate() < dia)) {
        idade--;
    }

    if (idade < 18) {
        document.getElementById('divResponsavel').style.display = 'block';
        document.getElementById('spanIdade').innerText = "(" + idade + " anos)";
        document.getElementById('hdnMantemEstado').value = 'block';
        document.getElementById('hdnIdade').value = idade;
    }
    else {
        document.getElementById('divResponsavel').style.display = 'none';
        document.getElementById('spanIdade').innerText = "";
        document.getElementById('hdnMantemEstado').value = 'none';
        document.getElementById('hdnIdade').value = idade;
    }
    return idade;
}

/*=-=-=-= Script responsável por manter a 'divResponsavel' visivel na página após o postback. =-=-=-=*/
function mantemEstadoDivResponsavel() {
    if (document.getElementById('hdnMantemEstado').value == 'none') {
        document.getElementById('divResponsavel').style.display = 'none';
    }
    else {
        document.getElementById('divResponsavel').style.display = 'block';
        document.getElementById('spanIdade').innerText = "(" + document.getElementById('hdnIdade').value + " anos)";
    }
}

function habilitaCamposNecessidadeEspecial() {
    var valor = document.querySelector('input[name="rblPortador"]:checked').value;

    if (valor == "S") {
        document.getElementById('divNecessidadeEspecial').style.display = 'block';
    }
    else {
        document.getElementById('divNecessidadeEspecial').style.display = 'none';
        document.getElementById('txtEspecificacao').value = '';
        document.getElementById('txtRecursos').value = '';
    }
}

function habilitaCampoOutraLingua() {
    try
    {
        var valor = document.querySelector('input[name="cbOutraLingua"]:checked').value;

        if (valor == "on") {
            document.getElementById('divOutraLingua').style.display = 'block';
        }
    }
    catch (ex)
    {
        document.getElementById('divOutraLingua').style.display = 'none';
        document.getElementById('txtOutraLingua').value = "";
    }
}

function habilitaCampoEmpresa() {
    var opcao = document.querySelector('input[name="rblTrabalho"]:checked').value;

    if (opcao == "S") {
        document.getElementById('divEmpresa').style.display = 'block';
    }
    else {
        document.getElementById('divEmpresa').style.display = 'none';
        document.getElementById('txtEmpresa').value = "";
    }
}

function habilitaCampoQualEnquete() {
    var opcao = document.getElementById('ddlEnquete').value;

    if (opcao == 1 || opcao == 2 || opcao == 3 || opcao == 4 || opcao == 0) {
        document.getElementById('divEnqueteQual').style.display = 'block';
        document.getElementById('divIndicacaoAmigo').style.display = 'none';
        document.getElementById('txtRAAmigo').value = "";
        document.getElementById('txtNomeAmigo').value = "";
    }
    /*else if(opcao == 7) {
        document.getElementById('divIndicacaoAmigo').style.display = 'block';
        document.getElementById('divEnqueteQual').style.display = 'none';
        document.getElementById('txtEnqueteQual').value = "";
    }*/
    else {
        document.getElementById('divEnqueteQual').style.display = 'none';
        document.getElementById('txtEnqueteQual').value = "";
        document.getElementById('divIndicacaoAmigo').style.display = 'none';
        document.getElementById('txtRAAmigo').value = "";
        document.getElementById('txtNomeAmigo').value = "";
    }
}

function habilitaCampoCepInvalido(divName) {
    var div = document.getElementById(divName);

    if (div.style.display == "none") {
        div.style.display = "block";
    } else {
        div.style.display = "none";
    }
}

/*=-=-=-= Limita a quantidade de caracteres no campo 'Especifique a necessidade especial' e
'Indique a necessidade de recursos adicionais para realização da prova'. =-=-=-=*/

function checkMaxLen(campo, maxLen) {
    try {
        if (campo.value.length > (maxLen - 1)) {
            var cont = campo.value;
            campo.value = cont.substring(0, (maxLen - 1));
            return false;
        };
    } catch (e) {
    }
}

function habilitaCampoEnem() {
    var valor = document.querySelector('input[name="rblEnem"]:checked').value;

    if (valor == "S") {
        document.getElementById('divNumeroEnem').style.display = 'block';
    }
    else {
        document.getElementById('divNumeroEnem').style.display = 'none';
        document.getElementById('txtNumeroEnem').value = '';
    }
}

/*=-=-=-= Controle de Marketing - Habilita o campo de busca, conforme a seleção. =-=-=-=*/
function habilitaBusca() {
    var busca = document.querySelector('input[name="rblTipoBusca"]:checked').value;

    if (busca == "data") {
        document.getElementById('divBuscaData').style.display = 'block';
        document.getElementById('divBuscaCPF').style.display = 'none';
    }
    else {
        document.getElementById('divBuscaData').style.display = 'none';
        document.getElementById('divBuscaCPF').style.display = 'block';
    }
}

function habilitaTipoBusca() {
    document.getElementById('divTipoBusca').style.display = 'block';
}