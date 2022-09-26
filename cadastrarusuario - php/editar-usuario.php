<?php

include 'Services/cadastra-usuario-services.php';
$usuariosServices = new UsuariosServices();

if($_SERVER['REQUEST_METHOD'] === 'POST')
{
    
    $dados = 
    [
        "id"=>$_POST['id'],
        "firstName"=>$_POST['nome'],
        "surName"=>$_POST['sobrenome'],
        "age"=>$_POST['idade']
    ];
    
    $json = json_encode($dados);
    
    $usuariosServices->atualizarUsuario($json, $_POST['id']);
    
    $usuariosServices->redirecionar("/cadastrarusuario");
}

$usuario = $usuariosServices->buscarPorId($_GET['id']);

?>
<!DOCTYPE html>
<html lang="pt-br">

<head>
    <link rel="stylesheet" type="text/css" href="style.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-iYQeCzEYFbKjA/T2uDLTpkwGzCiq6soy8tYaI1GyVh/UjpbCx/TYkiZhlZB6+fzT" crossorigin="anonymous">
    <meta charset="UTF-8">
    <title>Editar Usuario</title>
</head>

<body style="background-color: #34515f">
    <div id="container" >
        <h1 id="titulo">Editar Usuário</h1>
        <form action="editar-usuario.php" method="POST">
            <p class="campo-form">
                <label id="label-form">Digite o nome do usuário.</label>
                <br>
                <input  type="text" name="nome" id="nomeDoUsuario" value="<?php echo $usuario->firstName?>" />
            </p>
            <p class="campo-form">
                <label >Digite o sobrenome do usuário.</label>
                <br>
                <input type="text" name="sobrenome" id="sobrenomeDoUsuario" value="<?php echo $usuario->surName?>"/>
            </p>
            <p class="campo-form">
                <label >Digite a idade do usuário.</label>
                <br>
                <input type="text" name="idade" id="idadeDoUsuario" value="<?php echo $usuario->age?>"/>
            </p>
            <p id="botoes-formulario">
                    <button class="btn btn-success" name="id" value="<?php echo $_GET['id']?>">Editar Usuário</button>
                    <a class="btn btn-secondary " href="index.php">Voltar</a>
            </p>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-u1OknCvxWvY5kfmNBILK2hRnQC3Pr17a+RTT6rIHI7NnikvbZlHgTPOOmMi466C8" crossorigin="anonymous"></script>
</body>

</html>