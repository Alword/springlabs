package com.example.demo.controller;

import com.example.demo.dao.StudentJdbc;
import com.example.demo.model.Student;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/students")
public class StudentController {

    private final StudentJdbc studentJdbc;

    public StudentController(StudentJdbc studentJdbc) {
        this.studentJdbc = studentJdbc;
    }

    @GetMapping("")
    public List<Student> getStudents() {
        return studentJdbc.getAll();
    }

    @GetMapping("/{id}")
    public Student getStudent(@PathVariable int id) {
        return studentJdbc.get(id);
    }

    @GetMapping("/study_group/{studyGroupId}")
    public List<Student> getStudentByStudyGroup(@PathVariable int studyGroupId) {
        return studentJdbc.getAllByStudyGroup(studyGroupId);
    }

    @PostMapping(path = "", consumes = "application/json", produces = "application/json")
    public long addStudent(@RequestBody Student student) {
        return studentJdbc.create(student);
    }

    @PutMapping("/{id}")
    public int updateStudent(@PathVariable int id, @RequestBody Student student) {
        return studentJdbc.update(id, student);
    }

    @PutMapping("/transfer/{id}")
    public int transferStudent(@PathVariable int id, @RequestBody int studyGroupId) {
        return studentJdbc.transfer(id, studyGroupId);
    }

    @DeleteMapping("/{id}")
    public int deleteStudent(@PathVariable int id) {
        return studentJdbc.delete(id);
    }
}
