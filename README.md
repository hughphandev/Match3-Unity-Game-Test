# Evaluations
- Project sử dụng path để load resources & prefabs, điều này khiến cho việc load thuận tiện hơn nhưng cũng dễ gây lỗi (sai path nếu có người đổi tên đường dẫn hoặc tên constant)
- Class Item sử dụng inheritance để phân biệt normal và bonus items, điều này có thể tiết kiệm bộ nhớ hơn (chỉ thêm data vào class con) nhưng sẽ dẫn đến việc logic dễ bị dối hơn.

# Suggestions
- Nên có một Manager để có thể quản lý việc load/free resources.
- Prefer sử dụng Composition thay vì Inheritance để tránh việc logic dễ bị dối. Không nên cố gắng abstract vấn đề quá sớm mà nên tập trung giải quyết vấn đề cụ thể trước, trong nhiều trường hợp chỉ cần dùng một "Big Class" cũng có thể chấp nhận được. Khi vấn đề đã rõ ràng hơn ta có thể bắt đầu khoanh vùng phần code hay thay đổi lại và abstract nó qua interfaces.