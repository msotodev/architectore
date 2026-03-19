# 🚀 Architectore CLI



**Architectore CLI** is a .NET global tool designed to accelerate development using Clean Architecture principles.

It helps you automatically generate repositories, services, and query structures based on your domain entities.



---



## ✨ Features



* 🔹 Generate Repository layer (interfaces + implementations)

* 🔹 Generate Application Services

* 🔹 Generate Query layer (CQRS-ready structure)

* 🔹 CLI-based workflow with flexible flags

* 🔹 Designed for Clean Architecture projects

* 🔹 Extensible and template-friendly



---



## 📦 Installation



### Install globally (local package)



```bash

dotnet tool install --global --add-source ./bin/Release Architectore.CleanArchitecture

```



---



## 🚀 Usage



### Basic command



```bash

arch g --path "<PROJECT_PATH>" --namespace "<BASE_NAMESPACE>" --entity "<ENTITY_NAME>"

```



---



### Examples



#### Generate everything (default behavior)



```bash

arch g --path "C:\Repos\MyApp" --namespace "MyApp" --entity "User"

```



#### Generate only repositories



```bash

arch g --path "C:\Repos\MyApp" --namespace "MyApp" --entity "User" --repo

```



#### Generate services and queries



```bash

arch g --path "C:\Repos\MyApp" --namespace "MyApp" --entity "User" --repo "New,Update" --service "New,Update" --query "GetAll,GetById"

```



---



## ⚙️ Options



| Option        | Description                                   |

| ------------- | --------------------------------------------- |

| `--path`      | Base path of the project (required)           |

| `--namespace` | Base namespace for generated files (required) |

| `--entity`    | Entity name (e.g. `User`) (required)          |

| `--repo`      | Generate repository (Delete,New,Update)       |

| `--service`   | Generate service (Delete,New,Update)          |

| `--query`     | Generate query (GetAll,GetById)               |



---



## 📁 Output Structure



Generated files are placed in:



```

<path>

&#x20;├── Infrastructure/

&#x20;│   └── Repositories/

&#x20;├── Application/

&#x20;│   ├── Services/

&#x20;│   └── Queries/

```



---



## 🧠 Architecture Philosophy



This tool follows Clean Architecture principles:



* **Domain** → Entities and core business logic

* **Application** → Services and use cases

* **Infrastructure** → Data access and persistence



---



## 🔧 Development



### Build the tool



```bash

dotnet build

```



### Pack the tool



```bash

dotnet pack -c Release

```



---



## 📌 Roadmap



* [ ] Auto-detect entities from `Domain/Entities`

* [ x ] Support by entity (`User, Order, Product`)

* [ ] Support multiple entities (`User, Order, Product`)

* [ x ] Template engine for custom code generation

* [ ] Full CQRS support (Commands, Queries, Handlers)

* [ ] Integration with MediatR

* [ ] Namespace auto-detection from `.csproj`



---



## 🤝 Contributing



Contributions are welcome!



1. Fork the repository

2. Create a feature branch

3. Submit a pull request



---



## 📄 License



MIT License



---



## 👨‍💻 Author



Created by Mario Soto Moreno

.NET Developer focused on scalable architecture and clean code.



