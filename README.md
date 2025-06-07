# QuickHireUp API

API do zarządzania ogłoszeniami o pracę oraz generowania opisów stanowisk.



## Endpoints

## JobDescriptionController

Generowanie opisu stanowiska na podstawie podanych danych.

| Metoda | Endpoint                        | Opis                                     | Parametry (body)                                                             | Zwracany wynik                      |
|--------|--------------------------------|------------------------------------------|------------------------------------------------------------------------------|------------------------------------|
| POST   | `/api/JobDescription/generate` | Generuje opis stanowiska na podstawie danych wejściowych | JSON z danymi (JobTitle, Location, EmploymentType, ContractType, Experience) | JSON z polem `Description` - wygenerowany opis |

## Uwagi

- Endpoint asynchronicznie generuje tekst opisu na podstawie przesłanych danych.
- Zwraca JSON z polem `Description` zawierającym wygenerowany tekst.
- Aby generowanie opisów działało poprawnie, konieczne jest uruchomienie Ollama z modelem Mistral.
- Ollama należy uruchomić komendą:

  ```bash
  ollama run mistral

### JobAdsController

Zarządzanie ogłoszeniami o pracę.

| Metoda | Endpoint            | Opis                                                            | Parametry                             | Zwracany wynik                                                |
|--------|---------------------|-----------------------------------------------------------------|-------------------------------------|--------------------------------------------------------------|
| GET    | `/api/JobAds`       | Pobiera listę wszystkich ogłoszeń wraz z danymi firmy i umiejętnościami | Brak                                | Lista ogłoszeń z polami: Id, Title, Description, ExpirationDate, Company, Skills |
| GET    | `/api/JobAds/{id}`  | Pobiera szczegóły ogłoszenia o podanym `id`                     | `id` - ID ogłoszenia                 | Szczegóły ogłoszenia lub 404 jeśli nie znaleziono             |
| POST   | `/api/JobAds`       | Tworzy nowe ogłoszenie                                          | JSON z: Title, Description, ExpirationDate, CompanyId, SkillIds | Utworzone ogłoszenie (status 201 Created)                    |
| PUT    | `/api/JobAds/{id}`  | Aktualizuje istniejące ogłoszenie o podanym `id`               | `id` - ID ogłoszenia, JSON jak w POST | 204 No Content lub 404 jeśli nie znaleziono                   |
| DELETE | `/api/JobAds/{id}`  | Usuwa ogłoszenie o podanym `id`                                | `id` - ID ogłoszenia                 | 204 No Content lub 404 jeśli nie znaleziono                   |

