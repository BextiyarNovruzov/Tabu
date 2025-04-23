# 🎮 Tabu Game API

**Tabu Game API** — RESTful backend API that facilitates the digital version of the Taboo game. This API handles game sessions, player teams, word generation, taboo word validation, and scoring.

---

## 📜 Project Structure Overview

The project is divided into several key modules:

### 🔧 **Configurations**  
Contains configuration files such as `appsettings.json` and other environment-specific settings. It configures services, middleware, and database connections for the game.

### 🧑‍💻 **Controllers**  
The main logic for handling HTTP requests resides here. Controllers manage game sessions, teams, players, and words. Key actions:
- Start game session
- Manage teams
- Validate taboo words

### 🛠 **DAL (Data Access Layer)**  
Handles interactions with the database. It includes methods to manage entities such as players, teams, and game sessions.

### 📦 **DTOs (Data Transfer Objects)**  
Defines the data structures that are used to transfer information between the API and clients. These include game session details, team information, and player data.

### 🏢 **Entities**  
The main business models of the application, such as `Player`, `Team`, `GameSession`, and `TabooWord`, that are directly mapped to the database.

### ⚠ **Exceptions**  
Manages custom exceptions that are thrown when certain operations fail, such as validation errors or invalid actions.

### 📦 **Extensions**  
Contains helper methods and extension methods for reusable operations, like mapping between entities and DTOs, or validation checks.

### 🔄 **Migrations**  
Tracks changes to the database schema using Entity Framework migrations. It ensures the database is in sync with the latest model changes.

### 🗂 **Profiles**  
Defines how entities and DTOs are mapped to each other using libraries like AutoMapper. It helps convert between the internal database structures and the data that is exposed via API endpoints.

### 🔑 **Properties**  
Contains application settings and properties that influence the behavior of the game, such as game rules or time limits for each round.

### ⚙️ **Services**  
Contains core business logic that governs game operations, such as managing game sessions, calculating scores, and checking taboo words.

### 🧪 **Validators**  
Validates input data to ensure the API is being used correctly. This includes checking the correctness of team setups, word usage, and player actions.

### 📁 **Miscellaneous Files**  
Includes `Program.cs` (application entry point), `ServicesRegistration.cs` (service registration), and other files related to the build and runtime environment.

---

## 🧩 Main Functions

### 1. **CRUD Operations**
- **Teams**:
  - Create, read, update, and delete teams.
- **Players**:
  - Add/remove players to/from teams.
- **Words**:
  - CRUD operations for Taboo words and banned words.
- **Game Sessions**:
  - Start new games and track game state.

### 2. **Game Logic**
- **Start Game**: Initializes a new game session, assigns teams, and prepares the first round.
- **Word Generation**: Randomly selects a word with its taboo words for each round.
- **Taboo Word Check**: Validates if any forbidden words are used during the round.
- **Score Calculation**: Tracks points for each team and updates after each round.
- **End Game**: Determines the winning team and ends the session.

---

## 🛠 Technologies Used

- **ASP.NET Core Web API**
- **Entity Framework Core (Code-First)**
- **AutoMapper**
- **Microsoft SQL Server**
- **C#**

---

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/your-username/TabooGameAPI.git
