async function loadTasks() {
    const response = await fetch("/api/tasks");
    const tasks = await response.json();

    const list = document.getElementById("taskList");
    list.innerHTML = "";

    for (const task of tasks) {
        const li = document.createElement("li");
        li.textContent = task.title;

        const btn = document.createElement("button");
        btn.textContent = task.isCompleted ? "Undo" : "Done";
        btn.onclick = () => toggleTask(task.id, !task.isCompleted);

        li.appendChild(btn);
        list.appendChild("li");
    }
}

async function toggleTask(id, completed) {
    await fetch(`/api/tasks/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            id: id,
            title: "",
            isCompleted: completed
        })
    });

    loadTasks();
}

document.addEventListener("DOMContentLoaded", loadTasks);