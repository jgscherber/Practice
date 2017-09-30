	.file	"loop.c"
	.text
	.globl	main
	.type	main, @function
main:
.LFB0:
	.cfi_startproc
	// push current value of return register to stack (%rbp)
	// pushq: q suffice stands for "quadword" = 8 bytes
	// %rbp: base-pointer, points to base of current stack
	pushq	%rbp 
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	// movq = move quadword (8 bytes), S, D (source to destination)
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	// movl: move long (doubleword, 4 bytes)
	// moves a scaler ($) 0  which is an int (4 bytes in 64 bit C)
	// to 4 bytes before the base pointer (starts at high numbers,
	// moves down)
	movl	$0, -4(%rbp) // for(int i = 0;
	jmp	.L2
.L3:
	// add 1 from the S to the D
	addl	$1, -4(%rbp)
.L2:
	// cmpl: compare long (4 bytes) sets based on (S1 - S2)
	cmpl	$4, -4(%rbp) // i < 5 (i - 4 < 1)
	jle	.L3
	movl	$0, %eax //%eax just a register? not used before...
	popq	%rbp // remove pointer from stack
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE0:
	.size	main, .-main
	.ident	"GCC: (Ubuntu 6.3.0-12ubuntu2) 6.3.0 20170406"
	.section	.note.GNU-stack,"",@progbits
