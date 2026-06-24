# Veterinary Hospital Management System (VHMS)

A government-facing web application built to connect animal owners, veterinary doctors, pharmacies, and diagnostic labs on a single platform — enabling streamlined livestock and pet care, government subsidy access, and end-to-end treatment tracking.

---

## Overview

The **VHMS** (TSVUVHMS) is a centralized portal designed primarily to serve farmers and rural animal owners who need access to veterinary services and government-subsidized treatment. The system coordinates four key actors — animal owners, doctors, pharmacies, and diagnostic labs — into one unified workflow.

### Core Functions

| Actor | Capabilities |
|-------|-------------|
| **Animal Owner / Farmer** | Register animals, book appointments, access government subsidies |
| **Veterinary Doctor** | Record diagnoses, prescribe treatments, view patient visit history |
| **Pharmacy** | Receive prescriptions, issue and track drugs dispensed |
| **Diagnostic Lab** | Accept test orders, record and deliver diagnostic results |

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Frontend | ASP.NET Web Forms |
| Backend Logic | C# (.NET) |
| Database | Microsoft SQL Server (LocalDB / MSSQLLocalDB) |
| Scripting | JavaScript |
| Styling | CSS |

**Language breakdown:** ASP.NET 43.5% · C# 32.0% · JavaScript 17.5% · CSS 7.0%

---

## Architecture

The solution follows a **4-layer separation of concerns**, reflected directly in the project folder structure:

```
Veterinary-Hospital-Management-System/
│
├── TSVUVHMS_UI/          # Presentation layer — ASP.NET Web Forms (.aspx pages)
├── TSVUVHMS_BE/          # Backend / API layer — request handling and routing
├── TSVUVHMS_BL/          # Business logic layer — rules, workflows, validations
├── TSVUVHMS_DL/          # Data layer — SQL Server queries and data access
│
├── TSVUVHMS_UI.sln       # Visual Studio solution file
├── Dtls_PatientVisits.txt # Patient visit data reference / schema note
└── README.md
```

**Database:** `TSVUVHMS` on `(localdb)\MSSQLLocalDB`

---

## Features

- **Animal registration** — owners register livestock and pets with relevant details
- **Appointment booking** — owners schedule veterinary consultations
- **Government subsidy management** — farmers can apply for and track subsidies
- **Doctor diagnosis portal** — vets log diagnoses and treatment plans per visit
- **Pharmacy drug issuance** — pharmacies fulfill prescriptions tied to patient visits
- **Diagnostic testing** — labs receive test orders and return results linked to patient records
- **Patient visit history** — full visit log maintained per animal (`Dtls_PatientVisits`)

---

## Getting Started

### Prerequisites

- Visual Studio 2019 or later
- .NET Framework (version compatible with the solution)
- SQL Server or SQL Server LocalDB (`(localdb)\MSSQLLocalDB`)

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/steve-alex999/Veterinary-Hospital-Management-System.git
   ```

2. **Open the solution**
   Open `TSVUVHMS_UI.sln` in Visual Studio.

3. **Set up the database**
   - Create a new database named `TSVUVHMS` on your SQL Server / LocalDB instance.
   - Run any included SQL scripts to create the schema and seed data.
   - Update the connection string in the project configuration to point to your instance if needed.

4. **Build and run**
   Set `TSVUVHMS_UI` as the startup project, then press **F5** or select **Debug → Start Debugging**.

---

## Database

- **Server:** `(localdb)\MSSQLLocalDB`
- **Database name:** `TSVUVHMS`
- **Key table:** `Dtls_PatientVisits` — tracks per-animal visit records linked to diagnoses, prescriptions, and test results

---

## Contributing

Pull requests are welcome. For significant changes, please open an issue first to discuss what you'd like to change.

---

## Author

**Guzzarlapudi Stephen Sugun**
[github.com/steve-alex999](https://github.com/steve-alex999)
