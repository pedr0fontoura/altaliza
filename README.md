<h1 align="center">
  <br />
  <br />
  <img alt="Altaliza" src="https://user-images.githubusercontent.com/48810400/130319364-40a51bfe-2037-4bc2-b5d7-8e77f5c511b4.png" />
  <br />
  <br />
</h1>

<h3 align="center">
  Altaliza: Full-stack car rental application
</h3>

<p align="center">
  <a href="#-about-the-application">About the application</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-images">Images</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-how-to-use">How to use</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-api-documentation">API Documentation</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-application-features">Features</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#-license">License</a>
</p>

<br />

## 💬 About the application
This application was developed for a full-stack position.

The goal was to demonstrate my knowledge in C#, .NET Core and React.

## 📷 Images
<h4 align="center">
  <img alt="Altaliza" src="https://i.imgur.com/rKCaelJ.png" />
</h4>

<h4 align="center">
  <img alt="Altaliza" src="https://i.imgur.com/HrJ5h1P.png" />
</h4>

<h4 align="center">
  <img alt="Altaliza" src="https://i.imgur.com/iWrU61x.png" />
</h4>

<h4 align="center">
  <img alt="Altaliza" src="https://i.imgur.com/0ysWKZX.png" />
</h4>

<h4 align="center">
  <img alt="Altaliza" src="https://i.imgur.com/5QyXuCc.png" />
</h4>

<h4 align="center">
  <img alt="Altaliza" src="https://i.imgur.com/BWTAhSM.png" />
</h4>

## 💻 How to use
To clone and run this application you will need [Git](https://git-scm.com/), [Node.js v14.15.1+](https://nodejs.org/en/), [Yarn v1.22.5+](https://yarnpkg.com/) and [.NET Core 3.1](https://dotnet.microsoft.com/download).

On your shell:
```bash
# Clone the repository
$ git clone https://github.com/pedr0fontoura/cda-altaliza

# Navigate to the folder
$ cd cda-altaliza
```
To deploy the back-end, you'll need a MySQL server running. Fill the [settings](https://github.com/pedr0fontoura/cda-altaliza/blob/c55affb09f7b3db7ebb90467e1a8727b4f3755e0/backend/Altaliza.Infra/Context/MySqlContext.cs#L13) to your database credentials.

```bash
# Navigate to the back-end
$ cd backend

# Install the NuGet packages and build the application
$ dotnet build

# Update the database schema
$ dotnet ef database update --project Altaliza.Infra

# Run the application
$ dotnet run --project Altaliza.Application
```

To deploy the front-end, you'll need to fill the `.env` file using the [`.env.example`](https://github.com/pedr0fontoura/cda-altaliza/blob/main/frontend/.env.example) as example.

Then:
```bash
# Navigate to the front-end
$ cd frontend

# Install the application dependencies
$ yarn

# Run the react application
$ yarn start
```

## 🧰 API Documentation

You can access the SwaggerGen auto-generated documentation on the following URL `http://localhost:5000/swagger`

## ✨ Application features
- **List vehicles to rent**
- **Rent a vehicle for 1, 7, or 15 days**
- **1 day rent auto-renew**
- **Rental car return / manual renew**
- **List rented vehicles**
- **Mock authentication system on the front-end**

## 📝 License

This project is under MIT license. See the file [LICENSE](LICENSE) for more details.


<h1></h1>


Made by Pedro Fontoura :wave: [Get in touch!](https://www.linkedin.com/in/pffrd/)
