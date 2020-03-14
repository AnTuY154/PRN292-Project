<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProjectCSharpAdmin.UI.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Register</title>
    <meta name="description" content="Electric Shop Online" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="favicon.ico" />
    <link rel="stylesheet" href="../Assets/Public/Framework/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Assets/Public/Framework/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../Assets/Public/Css/style.css" />
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css' />
</head>
<body class="bg-dark">
    <div class="sufee-login d-flex align-content-center flex-wrap">
        <div class="container">
            <div class="login-content">
                <div class="login-logo">
                    <a href="index.html">
                        <img class="align-content" src="../Assets/Public/images/logo.png" alt=""/>
                    </a>
                </div>
                <div class="login-form">
                    <form>
                        <div class="form-group">
                            <label>UserName</label>
                            <input type="text" class="form-control" placeholder="Username"/>
                        </div>
                        <div class="form-group">
                            <label>Email address</label>
                            <input type="email" class="form-control" placeholder="Email"/>
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <input type="password" class="form-control" placeholder="Password"/>
                        </div>
                        <button type="submit" class="btn btn-primary btn-flat m-b-30 m-t-30">Register</button>
                        <div class="register-link m-t-15 text-center">
                            <p>Already have account ? <a href="#">Sign in</a></p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script src="../Assets/Public/Framework/jquery-3.4.1.min.js"></script>
    <script src="../Assets/Public/Framework/popper.min.js"></script>
    <script src="../Assets/Public/Framework/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
