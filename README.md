## Введение
Данный проект построен на основе фреймворка **Zenject**, который обеспечивает инъекцию зависимостей и управление контекстами. Основная структура проекта включает два контекста: глобальный и контекст сцены. Основной функционал реализован через две сцены: **InitialScene** и **GameplayScene**.

### InitialScene
На данном этапе **InitialScene** не содержит значимого функционала, но предназначена для выполнения первичной инициализации. Переход между сценами осуществляется через машину состояний.
### GameplayScene
При загрузке **GameplayScene** активируются **MonoInstaller**-ы, отвечающие за инициализацию и инъекцию зависимостей. Они разделяются на два типа:
- **Имитация внешних зависимостей**: например, установка главного персонажа и врагов.
- **Инициализация игровых систем**: например, системы лута и стрельбы.
## Архитектура проекта
Проект разделен на две основные папки:
- **Infrastructure**: код, отвечающий за загрузку сцен и управление глобальными процессами.
- **Logic**: код, реализующий игровую логику.
### Основные категории классов
1. **Behaviour-классы**
   Эти классы являются компонентами Unity и отвечают за поведение объектов на сцене. Примеры:
   - `ProjectileBehaviour`
   - `CharacterMovementBehaviour`
   - `FollowingGunnerBehaviour`

2. **System-классы**
   Отвечают за обработку поведения группы объектов и реализуются как обычные C# классы, часто с интерфейсами жизненного цикла Zenject. Примеры:
   - `ShootingSystem`
   - `LootSystem`

3. **Display/Screen-классы**
   - **Display**: небольшие индикаторы информации. Примеры:
	   - `AmmoCountDisplay`
   - **Screen**: интерфейсы, занимающие весь экран или его значительную часть. Примеры:
	   - `GameOverScreen`
	   - `LoadingScreen`

4. **Factory-классы**
   Реализуют паттерн **Factory** и создают объекты с использованием Zenject. Примеры:
   - `EnemyFactory`
   - `ProjectileFactory`

5. **Прочие классы**
   - `GameLoop`: управляет жизненным циклом геймплейной сцены.
   - `GameStateObserver`: следит за условиями проигрыша и другими событиями.
### Система управления
Существует две возможные реализации управления:
- **Старый Input**
- **Новая InputSystem**
### Работа камеры
Для управления камерой используется плагин **Cinemachine**.
## Использованные паттерны проектирования
В проекте применяются следующие паттерны:
- **State Machine**: управление состояниями игры, включая загрузку сцен через `BootstrapState` и `GameplayState`.
- **Observer**: слежение за состоянием игры с помощью `GameStateObserver`.
- **Dependency Injection**: управление зависимостями через Zenject.
- **Factory**: создание объектов через специализированные фабрики.