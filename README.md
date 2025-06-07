# QuickHireUp API

API do zarządzania ogłoszeniami o pracę oraz generowania opisów stanowisk.

## Endpoints

### JobAdsController

Zarządzanie ogłoszeniami o pracę.

| Metoda | Endpoint            | Opis                                                            | Parametry                             | Zwracany wynik                                                |
|--------|---------------------|-----------------------------------------------------------------|-------------------------------------|--------------------------------------------------------------|
| GET    | `/api/JobAds`       | Pobiera listę wszystkich ogłoszeń wraz z danymi firmy i umiejętnościami | Brak                                | Lista ogłoszeń z polami: Id, Title, Description, ExpirationDate, Company, Skills |
| GET    | `/api/JobAds/{id}`  | Pobiera szczegóły ogłoszenia o podanym `id`                     | `id` - ID ogłoszenia                 | Szczegóły ogłoszenia lub 404 jeśli nie znaleziono             |
| POST   | `/api/JobAds`       | Tworzy nowe ogłoszenie                                          | JSON z: Title, Description, ExpirationDate, CompanyId, SkillIds | Utworzone ogłoszenie (status 201 Created)                    |
| PUT    | `/api/JobAds/{id}`  | Aktualizuje istniejące ogłoszenie o podanym `id`               | `id` - ID ogłoszenia, JSON jak w POST | 204 No Content lub 404 jeśli nie znaleziono                   |
| DELETE | `/api/JobAds/{id}`  | Usuwa ogłoszenie o podanym `id`                                | `id` - ID ogłoszenia                 | 204 No Content lub 404 jeśli nie znaleziono                   |

## JobDescriptionController

Generowanie opisu stanowiska na podstawie podanych danych.

| Metoda | Endpoint                        | Opis                                     | Parametry (body)                         | Zwracany wynik                      |
|--------|--------------------------------|------------------------------------------|-----------------------------------------|------------------------------------|
| POST   | `/api/JobDescription/generate` | Generuje opis stanowiska na podstawie danych wejściowych | JSON z danymi np. JobTitle, Company, Responsibilities, Requirements | JSON z polem `Description` - wygenerowany opis |
