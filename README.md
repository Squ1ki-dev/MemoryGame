# MemoryGame
 
I used several patterns here: Extension Methods Pattern, Singleton Pattern, Facade Pattern, Observer Pattern, and Command Pattern. 
Extension Methods Pattern: Adding functionality to existing types without modifying their source code.
Singleton Pattern (Potential Use): Ensuring a single instance of SaveLoadService for consistent data management.
Facade Pattern: Simplifying interactions with complex subsystems (e.g., PlayerPrefs and JSON serialization).
Observer Pattern: Using events to notify subscribers of changes in the save.
Command Pattern: Encapsulating save/load operations in methods.

Additionally, I used sealed classes for SettingsService and SaveLoadService.
For SettingsService: Settings management logic remains consistent and reliable. By sealing this class, the integrity of its operations is preserved.
For SaveLoadService: Sealing this class ensures that the save and load settings methods are not modified through inheritance, ensuring data integrity.

All this allows you to safely and without problems add new types of cards, add new elements for saving (for example, the best score), and also customize the game to your needs
