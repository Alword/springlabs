package com.example.demo.controller;

import com.example.demo.dao.StudentJdbc;
import com.example.demo.model.Student;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("student")
public class StudentController {
    private final StudentJdbc studentJdbc;

    public StudentController(StudentJdbc studentJdbc) {
        this.studentJdbc = studentJdbc;
    }

    @GetMapping(value = "/{id}", produces = "application/json")
    public Student get(@PathVariable int id){
        Student student = studentJdbc.get(id);
        return student;
    }

    @PutMapping(value = "/{id}", produces = "application/json")
    public int put(@RequestBody Student student){
        int row = studentJdbc.update(student);
        return row;
    }

    @GetMapping(value = "/all", produces = "application/json")
    public List<Student> getAll(){
        List<Student> student = studentJdbc.getAll();
        return student;
    }

    @PostMapping(value = "/create", produces = "application/json")
    public int postCreate(@RequestBody Student student){
        int id = studentJdbc.create(student);
        return id;
    }

    @GetMapping(value = "/studygroupid/{id}", produces = "application/json")
    public List<Student> getStudyGroupId(@PathVariable int id){
        List<Student> student =  studentJdbc.getStudyGroupId(id);
        return student;
    }

    @DeleteMapping(value = "delete/{id}",produces = "application/json")
    public int delete(int id){
        int rows = studentJdbc.delete(id);
        return rows;
    }
}
