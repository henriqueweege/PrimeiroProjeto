<?php
include 'Services/cadastra-usuario-services.php';
$usuariosServices = new UsuariosServices();
$usuarios = $usuariosServices->exibirUsuarios();
?>


<!DOCTYPE html>
<html lang="pt-br">

<head>
    <title>Usuários Cadastrados</title>
    <meta charset="UTF-8">
    <link rel="stylesheet" type="text/css" href="style.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
</head>

<body style="background-color: #34515f">
    <div id="container">
        <a class="btn btn-secondary" href="adicionar-usuario.php" id="botao-adicionar">Adicionar Usuário</a>
        <h1 id="titulo">Usuários Cadastrados</h1>
        <div>
            <?php
        foreach($usuarios as $value ){?>
            <div class="row" id="row">
                <div class="col-3 p-2"><div class="p-2 bg-rgb(4, 58, 109) ">Nome: <?="$value->firstName"?></div></div>
                <div class="col-3 p-2"><div class="p-2 bg-rgb(4, 58, 109)">Sobrenome: <?="$value->surName"?></div></div>
                <div class="col-3 p-2"><div class="p-2 bg-rgb(4, 58, 109)">Idade: <?="$value->age"?></div></div>
                <div class="col-1 p-2"><a class=" btn btn-secondary btn-md" href="editar-usuario.php?id=<?php echo $value->id;?>">Editar</a></div>
                <div class="col-1 p-2"><a class=" btn btn-danger btn-md" href="excluir-usuario.php?id=<?php echo $value->id;?>">Excluir</a></div>
                             
            </div>
            <br>
            <?php } ?>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-u1OknCvxWvY5kfmNBILK2hRnQC3Pr17a+RTT6rIHI7NnikvbZlHgTPOOmMi466C8" crossorigin="anonymous"></script>
</body>
</html