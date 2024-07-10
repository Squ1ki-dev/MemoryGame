# MemoryGame

UNITY 2022.3.31f1
I spent 5.5 hours on this assessment.

I used several patterns, methods and interfaces here.
Extension Methods: This allows you to add functionality to existing classes without changing their source code or using inheritance.
Singleton Pattern: Ensuring a single instance of SaveLoadService for consistent data management.
Facade Pattern: Simplifying interactions with subsystems (e.g., PlayerPrefs and JSON serialization).
Observer Pattern: Using events to notify subscribers of changes in the save.
Command Pattern: Encapsulating save/load operations in methods.
Interfaces: For component registration, promoting loose coupling and flexibility.

Additionally, I used sealed classes for SettingsService and SaveLoadService.
For SettingsService: Settings management logic remains consistent and reliable. By sealing this class, the integrity of its operations is preserved.
For SaveLoadService: Sealing this class ensures that the save and load settings methods are not modified through inheritance, ensuring data integrity.

All this allows you to safely and without problems add new types of cards, add new elements for saving (for example, the best score), and also customize the game to your needs.
