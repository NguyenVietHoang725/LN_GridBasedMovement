# Sokoban Grid-Based Movement

## English Version

### Objective
Build a grid-based movement system in Unity for a Sokoban game.  
Create precise movement with box-pushing mechanics and effective collision handling.

### Idea
- Grid-based movement: characters and objects move in discrete grid cells only.  
- Movement checks target cell to prevent overlaps or pushing blocked boxes.  
- Boxes can be pushed if the next cell behind them is empty.  
- All objects are centrally managed by GridManager tracking positions.

### Implementation
- GridManager manages grid state and object positions via a dictionary.  
- Abstract GridObject class for all grid entities, registering and updating positions.  
- Player class handles input, movement and pushing logic.  
- Box class supports moving when pushed, respecting blocking rules.  
- Obstacles prevent movement onto occupied cells.

---

## Phiên bản tiếng Việt

### Mục tiêu
Xây dựng hệ thống di chuyển theo lưới trong Unity cho game Sokoban.  
Tạo cơ chế di chuyển chính xác, có thể đẩy hộp và xử lý va chạm hiệu quả.

### Ý tưởng
- Di chuyển theo lưới: nhân vật và đối tượng chỉ di chuyển theo ô vuông.  
- Kiểm tra ô đích tránh trùng, không đẩy được hộp bị chặn.  
- Hộp chỉ đẩy được khi ô phía sau trống.  
- Quản lý tập trung vị trí các đối tượng qua GridManager.

### Cách thực hiện
- GridManager quản lý trạng thái lưới bằng dictionary.  
- Lớp GridObject trừu tượng cho mọi đối tượng, quản lý vị trí.  
- Player xử lý nhập liệu, di chuyển và đẩy hộp.  
- Box cho phép di chuyển khi bị đẩy, tuân thủ luật vật cản.  
- Vật cản ngăn chặn việc đi lên ô đã bị chiếm.

