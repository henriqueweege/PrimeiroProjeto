<?php

if($_SERVER['REQUEST_METHOD'] === 'POST')
{
    include 'Services/cadastra-usuario-services.php';
    $usuariosServices = new UsuariosServices();
    
    $dados = 
    [
        "firstName"=>$_POST['nome'],
        "surName"=>$_POST['sobrenome'],
        "age"=>$_POST['idade']
    ];

    $json = json_encode($dados);

    $usuariosServices->cadastrarUsuario($json);
    $usuariosServices->redirecionar('/cadastrarusuario');
    
}

?>
<!DOCTYPE html>
<html lang="pt-br">

<head>
    <link rel="stylesheet" type="text/css" href="style.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
    <meta charset="UTF-8">
    <title>Adicionar Usuário</title>
</head>

<body style="background-color: #34515f">
    <div id="container">
        <h1 id="titulo">Adicionar Usuário</h1>
        <form action="adicionar-usuario.php" method="post">
            <p class="campo-form">
                <label>Digite o nome do usuário.</label>
                <br>
                <input  type="text" name="nome"/>
            </p>
            <p class="campo-form">
                <label>Digite o sobrenome do usuário.</label>
                <br>
                <input  type="text" name="sobrenome"/>
            </p>
            <p class="campo-form">
                <label>Digite a idade do usuário.</label>
                <br>
                <input  type="text" name="idade"/>
            </p>
            <p id="botoes-formulario">
                <button class="btn btn-success">Cadastrar Usuário</button>
                <a class="btn btn-secondary " href="index.php">Voltar</a>
            </p>
        </form>
    </div>
</body>

</html>