# EDR-Antivirus-Bypass-to-Gain-Shell-Access

## EDR & Antivirus Bypass to Gain Shell Access

This repository contains a **proof-of-concept (PoC)** for bypassing EDR and antivirus solutions using a memory injection technique. The code executes shellcode that spawns a reverse shell, successfully evading detection by various security mechanisms.

---

## Description

This project demonstrates how to bypass EDR and antivirus protection using Windows API functions such as `VirtualAlloc`, `CreateThread`, and `WaitForSingleObject`. The payload is injected directly into the process memory without being detected by security tools, establishing a connection to a remote system for a reverse shell.

> **Disclaimer:** This code is for educational purposes only. Use it responsibly and only in environments where you have explicit permission to test.

---

## Features

- Bypasses standard EDR and antivirus solutions
- Executes shellcode in memory to create a reverse shell
- Utilizes `VirtualAlloc` and `CreateThread` to inject the payload directly into process memory

---

## Requirements

- Windows Operating System (Tested on Windows 10)
- Kali Linux (For reverse shell listener)
- Visual Studio or any C# compiler

---

## Steps to Compile & Run

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/EDR-Antivirus-Bypass-Shell.git
cd EDR-Antivirus-Bypass-Shell
