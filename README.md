# Route - Inclusive Indoor Positioning System 🧭

## 📖 About the Project
**Route** is an accessible indoor navigation and wayfinding system designed to provide autonomy for blind and visually impaired individuals. Utilizing Bluetooth Low Energy (BLE) beacons and routing algorithms, the system accurately calculates real-time positioning and provides spatial guidance within complex indoor environments. 

The ecosystem consists of an **ASP.NET Core Web API** for backend management and a **.NET MAUI** mobile application tailored for high accessibility and usability.

## 🚀 Technologies Used
* **Backend:** C#, ASP.NET Core 8 Web API, Entity Framework Core
* **Database:** MySQL (Pomelo EF Core Provider) hosted on Aiven Cloud
* **Mobile:** C#, .NET MAUI
* **Hardware Integration:** Bluetooth Low Energy (BLE) Beacons
* **Security:** BCrypt for password hashing, .NET User Secrets for credential management

## 🚧 Ongoing Work
This project is currently under active development. The immediate roadmap includes:
* **Authentication Module:** Implementing the UI and backend flows for User Registration, Login, and Forgot Password mechanisms.
* **Database Migration:** Finalizing the transition to the cloud-based MySQL architecture on Aiven.
---

## ⚙️ Getting Started

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Visual Studio 2022 (with *ASP.NET and web development* and *.NET Multi-platform App UI development* workloads)
* A MySQL instance (Local or Cloud/Aiven)

### Installation & Configuration

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/your-username/RouteDevelopment.git](https://github.com/your-username/RouteDevelopment.git)
   cd RouteDevelopment
