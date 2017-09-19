	.file	"math.c"
	.section	.rodata
.LC0:
	.string	"%d"
	.text
	.globl	main
	.type	main, @function
main:
.LFB0: ; labels, usually referenced by exception-handling related code
	; .cfi* are used by compiler to help traverse stack for exception handling
	.cfi_startproc
	pushq	%rbp ; push the base point of the stack (quadword)
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	subq	$32, %rsp ; subtrack 32 from stack pointer (4 * 8) but 5 ints defined?
	movl	$3, -20(%rbp) ; a = 3
	movl	$5, -16(%rbp) ; b = 5;
	movl	-20(%rbp), %edx ; move value of a to %edx (bytes 5-8 of register %rdx)
	movl	-16(%rbp), %eax ; move value of b to %eax (byte 5-8 of %rax)
	addl	%edx, %eax ; a + b , saved in %eax
	movl	%eax, -12(%rbp) ; move to c ( -12(%rbp))
	movl	$15, -8(%rbp) ; compiler did the 3 * 5
	movl	$0, -4(%rbp) ; and the 3/5
	movl	-20(%rbp), %eax ; move value of a to last 4 byes of %rax
	movl	%eax, %esi ; move to last 4 bytes of %rsi
	movl	$.LC0, %edi ; move thing at jump .LCO (.string("%d")) to %edi
	movl	$0, %eax ; clear %eax
	call	printf ; printf does it's thing
	movl	$0, %eax ; clear %eax again
	; leave is equivalent to: (undoes the pushq and movq at the top)
	; movq %rbp, %rsp
	; popq %rbp
	leave
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE0:
	.size	main, .-main
	.ident	"GCC: (Ubuntu 5.4.0-6ubuntu1~16.04.4) 5.4.0 20160609"
	.section	.note.GNU-stack,"",@progbits
