<?php


if($_SERVER['REQUEST_METHOD'] === 'POST')
{
    include 'Services/cadastra-usuario-services.php';
    $usuariosServices = new UsuariosServices();
    
    $dados = 
    [
        "id"=>$_POST['id'],
        "firstName"=>$_POST['nome'],
        "surName"=>$_POST['sobrenome'],
        "idade"=>$_POST['idade']
    ];

    $json = json_encode($dados);

    $usuariosServices->atualizarUsuario($json, $_POST['id']);

    $usuariosServices->redirecionar("/cadastrarusuario");
}

?>
<!DOCTYPE html>
<html lang="pt-br">

<head>
    <link rel="stylesheet" type="text/css" href="style.css">
    <meta charset="UTF-8">
    <title>Editar Usuario</title>
</head>

<body>
    <div id="container" >
        <h1>Editar Usuario</h1>
        <form action="editar-usuario.php" method="POST">
            <p class="campo-form">
                <label id="label-form">Digite o nome do usuário.</label>
                <br>
                <input  type="text" name="nome"/>
            </p>
            <p class="campo-form">
                <label >Digite o sobrenome do usuário.</label>
                <br>
                <input type="text" name="sobrenome"/>
            </p>
            <p class="campo-form">
                <label >Digite a idade do usuário.</label>
                <br>
                <input type="text" name="idade"/>
            </p>
            <p >
                <button class="botao" name="id" value="<?php echo $_GET['id']?>">Atualizar Usuário</button>
            </p>
        </form>
    </div>
</body>

</html>