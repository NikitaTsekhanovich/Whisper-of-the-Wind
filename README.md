# Windswept-Tale

# Описание 

Играешь за листик. Он летит вперед, управлять можно только вертикальным положением за счет нажатия на экран. Один раз нажал, листик подлетел.
Нужно избегать удара об ветки и падения на землю, иначе игра будет проиграна. 

Локации.
Локаций 5 видов. На каждой уникальный спавн веток, монеток, абилок неуязвимости и ускоряющих потоков. После каждой пройденной локации скорость игры увеличивается. 

Объекты. 
Монеты. Появляются рандомными кучами на локации. За них можно покупать скины в магазине (новые листы).
Ускоряющие потоки. Если попасть в такой поток, то скорость увеличится, если из него выйти, скорость станет прежней. 
Абилка неуязвимости. Дает неуязвимость на 5 секунд и спасает от ударов об ветки, но не спасает от падения на землю. 

Счет.
Счет увеличивается в зависимости от пройденного расстояния. Есть сохранение лучшего счета.


Если 10 раз нажать на лого, на счет упад 1000 монет. Для тестирования магазина.

# Особенности

Писал шейдер для воздушых потоков, чтобы создать анимацию полета.

Проект реализован через ECS паттерн, а именно LeoECS фреймворк. Также, использовал провайдер для компонентов UniLeo. Для тестирования проекта нужно установить следующие фреймворки:

https://github.com/Leopotam/ecs
https://github.com/voody2506/UniLeo.git

# Скриншоты

![Image Sequence_015_0000](https://github.com/user-attachments/assets/f5680cb5-7fbf-4fd4-82dd-f0272303e4ab)
![Image Sequence_012_0000](https://github.com/user-attachments/assets/1cefc92e-9742-473c-b543-969188bcf369)
![Image Sequence_009_0000](https://github.com/user-attachments/assets/b7511d21-5d58-4257-90ad-f70a3486eaa6)
![Image Sequence_007_0000](https://github.com/user-attachments/assets/eae07f36-647c-4d95-bb89-aebfe17df5b7)
![Image Sequence_004_0000](https://github.com/user-attachments/assets/ceb8a028-d393-4bb7-96a7-bb7bc52406e4)
![Image Sequence_002_0000](https://github.com/user-attachments/assets/80e41c53-a2e5-49e4-b388-8650875b71d1)
