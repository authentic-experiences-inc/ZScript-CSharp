cmake_minimum_required(VERSION 3.5)

project(hello_library C)

add_definitions(-DZINTERP_DLL)

add_library(hello_library SHARED 
    src/Hello.c
)

target_include_directories(hello_library
    PUBLIC 
        ${PROJECT_SOURCE_DIR}/include
)

if (WIN32)
        target_link_libraries(hello_library winmm ws2_32)
        SET_TARGET_PROPERTIES(hello_library PROPERTIES PREFIX "")
    endif()
