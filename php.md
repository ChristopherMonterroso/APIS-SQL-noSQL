# Symfony CRUD con MySQL y Bootstrap

Este proyecto es una aplicación web en **Symfony 6.1** con **PHP 8.0** y **MySQL**, que permite gestionar usuarios con un **CRUD completo** (Crear, Leer, Actualizar y Eliminar).
Se ha mejorado el diseño utilizando **Bootstrap**.

---

## 📌 1️⃣ Instalación de PHP 8.0 y Composer

### **1.1 Descargar e instalar PHP 8.0**

1. Descarga **PHP 8.0** desde:
   👉 [https://windows.php.net/downloads/releases/archives/](https://windows.php.net/downloads/releases/archives/)
2. Descarga la versión **Thread Safe** (`php-8.0.x-Win32-vs16-x64.zip`).
3. Extrae los archivos en `C:\php80`.
4. Renombra `php.ini-development` a `php.ini` y habilita estas extensiones quitando el `;`:
   ```ini
   extension=mbstring
   extension=mysqli
   extension=pdo_mysql
   extension=intl
   extension=zip
   ```
5. Agrega `C:\php80` a la variable de entorno `PATH`.
6. Verifica la instalación:
   ```sh
   php -v
   ```

### **1.2 Instalar Composer**

1. Descarga **Composer** desde:
   👉 [https://getcomposer.org/download/](https://getcomposer.org/download/)
2. Instálalo y verifica:
   ```sh
   composer -V
   ```

---

## 📌 2️⃣ Instalación de Symfony

### **2.1 Instalar Symfony CLI**

Descarga Symfony CLI desde:
👉 [https://symfony.com/download](https://symfony.com/download)

Si solo tienes `symfony.exe`, muévelo a `C:\SymfonyCLI` y agrégalo al `PATH`.

Verifica la instalación:

```sh
symfony version
```

### **2.2 Crear un nuevo proyecto Symfony**

```sh
composer create-project symfony/website-skeleton my_project
cd my_project
```

Inicia el servidor:

```sh
symfony server:start
```

Abre en el navegador:
👉 `http://127.0.0.1:8000/`

---

## 📌 3️⃣ Configurar Base de Datos (MySQL)

1. Abre el archivo `.env` y cambia:
   ```ini
   DATABASE_URL="mysql://root:tucontraseña@127.0.0.1:3306/symfony_db"
   ```
2. Crea la base de datos:
   ```sh
   php bin/console doctrine:database:create
   ```

---

## 📌 4️⃣ Crear la Entidad `User`

```sh
php bin/console make:entity User
```

Agrega los siguientes campos:

* `name` → string (100 caracteres)
* `email` → string (180 caracteres, único)

Aplica los cambios en la base de datos:

```sh
php bin/console make:migration
php bin/console doctrine:migrations:migrate
```

---

## 📌 5️⃣ Generar un CRUD Automático

Instalar dependencias necesarias:

```sh
composer require annotations
```

Generar el CRUD:

```sh
php bin/console make:crud User
```

---

## 📌 6️⃣ Insertar Datos de Prueba

```sh
php bin/console doctrine:query:sql "INSERT INTO user (name, email) VALUES ('Christopher', 'chris@example.com')"
```

---

## 📌 7️⃣ Acceder a la Aplicación

📌 **Lista de usuarios:**
👉 `http://127.0.0.1:8000/user/`

📌 **Crear usuario:**
👉 `http://127.0.0.1:8000/user/new`

📌 **Editar usuario (`id = 1`):**
👉 `http://127.0.0.1:8000/user/1/edit`

---

## 📌 8️⃣ Mejorar el Diseño con Bootstrap

Agregar Bootstrap en `templates/base.html.twig`:

```twig
<head>
    <meta charset="UTF-8">
    <title>{% block title %}Symfony App{% endblock %}</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
    <script src="https://kit.fontawesome.com/a076d05399.js" crossorigin="anonymous"></script>
</head>
```

Mejorar la vista de `templates/user/index.html.twig`:

```twig
{% extends 'base.html.twig' %}

{% block title %}Lista de Usuarios{% endblock %}

{% block body %}
<div class="container mt-5">
    <h1 class="mb-4 text-center">Lista de Usuarios</h1>

    <div class="d-flex justify-content-end mb-3">
        <a href="{{ path('app_user_new') }}" class="btn btn-success">
            <i class="fas fa-user-plus"></i> Crear Usuario
        </a>
    </div>

    <div class="table-responsive">
        <table class="table table-striped table-hover text-center shadow-sm">
            <thead class="table-dark">
                <tr>
                    <th>ID</th>
                    <th>Nombre</th>
                    <th>Email</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                {% for user in users %}
                    <tr>
                        <td>{{ user.id }}</td>
                        <td>{{ user.name }}</td>
                        <td>{{ user.email }}</td>
                        <td>
                            <a href="{{ path('app_user_show', {'id': user.id}) }}" class="btn btn-info btn-sm">
                                <i class="fas fa-eye"></i> Ver
                            </a>
                            <a href="{{ path('app_user_edit', {'id': user.id}) }}" class="btn btn-warning btn-sm">
                                <i class="fas fa-edit"></i> Editar
                            </a>
                        </td>
                    </tr>
                {% else %}
                    <tr>
                        <td colspan="4" class="text-muted">No hay usuarios registrados.</td>
                    </tr>
                {% endfor %}
            </tbody>
        </table>
    </div>
</div>
{% endblock %}
```
